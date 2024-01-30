using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon_Movment_Manager : MonoBehaviour
{
    private Animator animator;
    private bool isAPressed = false;
    private bool isDPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("Movment_Derecha", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Movment_Derecha", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("Movment_Izquierda", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Movment_Izquierda", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("Movment_Up", true);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, +0.2f);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.2f);
            animator.SetBool("Movment_Up", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("Movment_Down", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("Movment_Down", false);
        }


        MovmentWithKeys();
    }

    public void MovmentWithKeys()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isAPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isDPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && !isAPressed && !isDPressed)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, +0.2f);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            isDPressed = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            isAPressed = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.2f);
        }
    }
}
