using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon_Movment_Manager : MonoBehaviour
{
    private Animator animator;
    private bool isWPressed = false;
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            isWPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isWPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && isWPressed == false)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, +0.2f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isWPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isWPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isWPressed = false;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.2f);
        }



    }
}

