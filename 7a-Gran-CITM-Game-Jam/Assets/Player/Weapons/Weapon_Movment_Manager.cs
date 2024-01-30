using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Movment_Manager : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Cambia el valor del parámetro booleano a true
            animator.SetBool("Movment_Izquierda", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Movment_Izquierda", false);
        }
       
    }
}
