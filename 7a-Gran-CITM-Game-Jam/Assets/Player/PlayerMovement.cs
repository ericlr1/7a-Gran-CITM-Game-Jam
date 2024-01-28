using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rigidBody;
    public Animator animator;

    Vector2 movment;

    // Update is called once per frame
    void Update()
    {
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movment.x);
        animator.SetFloat("Vertical", movment.y);
        animator.SetFloat("Speed", movment.sqrMagnitude);
    }
    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movment * moveSpeed * Time.fixedDeltaTime);
    }
}