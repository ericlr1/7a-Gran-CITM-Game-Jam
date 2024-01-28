using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForce : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 originalPosition;

    public float fuerzaRetroceso = 10f;
    public float tiempoParaVolver = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Guarda la posición original
            originalPosition = transform.position;

            // Aplica una fuerza hacia atrás
            rb.AddForce(-transform.forward * fuerzaRetroceso, ForceMode.Impulse);

            // Inicia una coroutine para volver a la posición original después de un tiempo
            StartCoroutine(VolverAPosicionOriginal());
        }
    }

    IEnumerator VolverAPosicionOriginal()
    {
        // Espera durante el tiempo especificado
        yield return new WaitForSeconds(tiempoParaVolver);

        // Vuelve al punto original
        transform.position = originalPosition;
    }
}
