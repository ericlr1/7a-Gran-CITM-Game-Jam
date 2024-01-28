using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float bulletSpeed = 10f;
    public Rigidbody2D bulletPrefab;

    public Rigidbody2D rigidBody;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        // Determina la direcci�n del disparo seg�n la direcci�n del movimiento
        if (movement != Vector2.zero)
        {
            // Si el jugador no se est� moviendo, la bala dispara en la �ltima direcci�n de movimiento
            Rigidbody2D bulletInstance = Instantiate(bulletPrefab, rigidBody.position, Quaternion.identity);
            Vector2 lastMovementDirection = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
            bulletInstance.velocity = lastMovementDirection.normalized * bulletSpeed;
        }
    }
}
