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
        // Determina la dirección del disparo según la dirección del movimiento
        if (movement != Vector2.zero)
        {
            // Si el jugador no se está moviendo, la bala dispara en la última dirección de movimiento
            Rigidbody2D bulletInstance = Instantiate(bulletPrefab, rigidBody.position, Quaternion.identity);
            Vector2 lastMovementDirection = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
            bulletInstance.velocity = lastMovementDirection.normalized * bulletSpeed;
        }
    }
}
