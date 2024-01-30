using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class TwinStickMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private bool isGamepad;
    private CharacterController controller;
    private PlayerControls playerControls;
    private PlayerInput playerInput;
    private Vector2 movement;

    private Vector2 aim;
    public Animator animator;

    public float bulletSpeed = 10f;
    public Rigidbody2D bulletPrefab;
    public Transform shootingPoint;
    public float vibrationDuration = 0.05f;
    private Gamepad gamepad = null;
    private bool canShoot = true;

    public CinemachineVirtualCamera mainCamera;
    public float zoomDuration = 0.7f;
    public float zoomAmount = 5.0f;
    private float originalFieldOfView;
    private float targetFieldOfView;
    private bool isZooming = false;
    private float zoomTimer = 0.0f;
    public float cadenciaWeapon = 50.0f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
        gamepad = Gamepad.current;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        originalFieldOfView = mainCamera.m_Lens.FieldOfView;
    }

    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();

        if ((Input.GetButtonDown("Fire1") || Input.GetAxis("Left Trigger") > 0.5 || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && canShoot == true)
        {
            StartCoroutine(ShootCooldown());
            Shoot();
        }

        // Si estamos haciendo zoom, actualiza el FOV de la cámara de forma suave
        if (isZooming)
        {
            zoomTimer += Time.deltaTime;
            float progress = Mathf.Clamp01(zoomTimer / zoomDuration);

            // Interpola suavemente entre el FOV actual y el objetivo
            float newFieldOfView = Mathf.Lerp(mainCamera.m_Lens.FieldOfView, targetFieldOfView, progress);
            mainCamera.m_Lens.FieldOfView = newFieldOfView;

            // Si hemos alcanzado el valor objetivo, detenemos el zoom
            if (progress == 1.0f)
            {
                isZooming = false;
            }
        }
    }

    void HandleInput()
    {
        movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        aim = playerControls.Controls.Aim.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        Vector3 move = new Vector3(movement.x, movement.y, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    void HandleRotation()
    {
        if (aim.x != 0 || aim.y != 0)
        {
            animator.SetFloat("AimX", aim.x);
            animator.SetFloat("AimY", aim.y);
        }
        else
        {
            animator.SetFloat("AimX", movement.x);
            animator.SetFloat("AimY", movement.y);
        }
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }

    IEnumerator ShootCooldown()
    {
        Debug.Log("Cooldown ON");
        canShoot = false;

        yield return new WaitForSeconds(cadenciaWeapon * Time.deltaTime);

        Debug.Log("Cooldown OFF");
        canShoot = true; 
    }

    void Shoot()
    {
        Debug.Log("SHOOT!");

        if (gamepad != null)
        {
            StartCoroutine(VibrateController());
        }

        StartCoroutine(RecoilCamera());

        Rigidbody2D bulletInstance = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

        if (animator.GetFloat("AimX") != 0 || animator.GetFloat("AimY") != 0)
        {
            bulletInstance.velocity = new Vector2(animator.GetFloat("AimX"), animator.GetFloat("AimY")).normalized * bulletSpeed;
        }
        else
        {
            bulletInstance.velocity = Vector2.down * bulletSpeed;
        }

        double transitionPoint = 0.75;

        if (animator.GetFloat("AimY") >= transitionPoint)
        {
            bulletInstance.velocity = Vector2.up * bulletSpeed;
            return;
        }
        else if (animator.GetFloat("AimY") < -transitionPoint)
        {
            bulletInstance.velocity = Vector2.down * bulletSpeed;
            return;
        }
        else if (animator.GetFloat("AimX") >= transitionPoint)
        {
            bulletInstance.velocity = Vector2.right * bulletSpeed;
            return;
        }
        else if (animator.GetFloat("AimX") < -transitionPoint)
        {
            bulletInstance.velocity = Vector2.left * bulletSpeed;
            return;
        }
    }

    IEnumerator VibrateController()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0.2f, 0.2f);
            yield return new WaitForSeconds(vibrationDuration);
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }

    IEnumerator RecoilCamera()
    {
        StartZoom();
        yield return new WaitForSeconds(zoomDuration * Time.deltaTime);
        ResetZoom();
    }

    void StartZoom()
    {
        //Debug.Log("Zoom In");
        targetFieldOfView = originalFieldOfView - zoomAmount;
        isZooming = true;
        zoomTimer = 0.0f;
    }

    void ResetZoom()
    {
        //Debug.Log("Zoom Out");
        targetFieldOfView = originalFieldOfView;
        isZooming = true;
        zoomTimer = 0.0f;
    }
}
