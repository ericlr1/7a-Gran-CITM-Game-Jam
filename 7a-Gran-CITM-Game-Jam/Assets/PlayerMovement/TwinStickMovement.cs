using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class TwinStickMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float gamepadRotateSmoothing = 1000f;

    [SerializeField] private bool isGamepad;

    private CharacterController controller;

    public Animator animator;

    private Vector2 movement;
    private Vector2 aim;

    private Vector3 playerVelocity;

    private PlayerControls playerControls;
    private PlayerInput playerInput;

    public float bulletSpeed = 10f;
    public Rigidbody2D bulletPrefab;
    public Transform shootingPoint;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable(); 
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
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
        if(isGamepad)
        {
            animator.SetFloat("AimX", aim.x);
            animator.SetFloat("AimY", aim.y);
        }
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }


    void Shoot()
    {
        Rigidbody2D bulletInstance = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

        if (animator.GetFloat("AimX") != 0 || animator.GetFloat("AimY") != 0)
        {
            bulletInstance.velocity = new Vector2(animator.GetFloat("AimX"), animator.GetFloat("AimY")).normalized * bulletSpeed;
        }
        else
        {
            bulletInstance.velocity = Vector2.down * bulletSpeed;
        }

        //Mirar como afecta esto a las posiciones relativas del apuntado con el mando & meter el || de las teclas/botones mando y teclado
        if(animator.GetFloat("AimX") > 0.75) { }
        else if(animator.GetFloat("AimX") > 0.75) { }
        else if(animator.GetFloat("AimX") > 0.75) { }
        else if(animator.GetFloat("AimX") > 0.75) { }





        // Determina la dirección del disparo según la dirección del movimiento
        //if (movement != Vector2.zero)
        //{
        //    // Si el jugador no se está moviendo, la bala dispara en la última dirección de movimiento
        //    Vector2 lastMovementDirection = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        //    bulletInstance.velocity = lastMovementDirection.normalized * bulletSpeed;
        //}
        //else
        //{
        //    Debug.Log("Mov: 0");
        //    bulletInstance.velocity = Vector2.down * bulletSpeed;
        //}
    }
}
