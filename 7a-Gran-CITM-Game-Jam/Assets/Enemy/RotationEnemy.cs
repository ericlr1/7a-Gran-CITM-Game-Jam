using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEnemy : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Player player = PlayerManager.Instance.Player;
        
        if (player != null)
        {
            Vector3 direccion = player.transform.position - transform.position;

            if (direccion.x > 0)
            { 
                animator.SetBool("Derecha", true);
            }
            else
            {
                animator.SetBool("Derecha", false);

            }
        }
    }

  
}
