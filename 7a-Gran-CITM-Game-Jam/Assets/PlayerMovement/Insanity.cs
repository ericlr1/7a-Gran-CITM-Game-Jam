using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Insanity : MonoBehaviour
{
    // Referencia al Animator
    public Animator animator;

    // Valor de la cordura
    private float insanityValue = 0.0f;

    public float insanityHitValue = 1f;

    // M�todo que se llama cuando otro Collider entra en contacto con este Collider
    void OnTriggerEnter2D(Collider2D other)
    {
       
        // Verificar si el otro GameObject tiene la etiqueta "Enemy"
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            AddInsanity();
            animator.SetFloat("Insanity", insanityValue);

            // Aqu� puedes agregar cualquier otra l�gica que desees cuando un enemigo toque este objeto
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Teddy_Bear"))
        {
            Debug.Log("Hit Bear");
            ReduceInsanity();
            animator.SetFloat("Insanity", insanityValue);

            other.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddInsanity()
    {
        if (insanityValue < 3)
        {
            Debug.Log("AddInsanity");
            insanityValue += insanityHitValue;
            //Poner sonido de da�o

        }
        else
        {
            SceneManager.LoadScene("Dead");
        }
    }

    private void ReduceInsanity()
    {
        if (insanityValue > 0)
        {
            Debug.Log("ReduceInsanity");
            insanityValue -= insanityHitValue;
            //Poner sonido de cura

        }
    }
}
