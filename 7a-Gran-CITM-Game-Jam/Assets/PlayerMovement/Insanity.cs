using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insanity : MonoBehaviour
{
    // Referencia al Animator
    public Animator animator;

    // Valor de la cordura
    private float insanityValue = 0.0f;

    public float insanityHitValue = 1f;

    // Método que se llama cuando otro Collider entra en contacto con este Collider
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        // Verificar si el otro GameObject tiene la etiqueta "Enemy"
        if (other.CompareTag("Enemy"))
        {
            AddInsanity();
            animator.SetFloat("Insanity", insanityValue);

            // Aquí puedes agregar cualquier otra lógica que desees cuando un enemigo toque este objeto
            other.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddInsanity()
    {
        Debug.Log("AddInsanity");
        insanityValue += insanityHitValue;
    }

    private void ReduceInsanity()
    {
        Debug.Log("ReduceInsanity");
        insanityValue -= insanityHitValue;
    }
}
