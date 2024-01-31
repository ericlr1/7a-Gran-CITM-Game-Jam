using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMovment : MonoBehaviour
{
    public float radioMovimiento = 5f;
    public float velocidadMovimiento = 2f;

    void Start()
    {
        // Llama a la funci�n para iniciar el movimiento aleatorio
        MoverAleatoriamente();
    }

    void Update()
    {
        // Puedes agregar otros comportamientos o l�gica aqu� si es necesario
    }

    void MoverAleatoriamente()
    {
        // Obtiene una posici�n aleatoria dentro de un c�rculo unitario y la escala por el radio deseado
        Vector2 direccionAleatoria = Random.insideUnitCircle.normalized * radioMovimiento;

        // Establece la posici�n inicial del objeto en la posici�n aleatoria dentro del radio
        transform.position = new Vector3(direccionAleatoria.x, direccionAleatoria.y, 0f);

        // Inicia la coroutine para el movimiento suave
        StartCoroutine(MoverSuavemente());
    }

    System.Collections.IEnumerator MoverSuavemente()
    {
        while (true)
        {
            // Obtiene una direcci�n aleatoria en cada frame
            Vector2 direccionAleatoria = Random.insideUnitCircle.normalized;

            // Calcula la nueva posici�n del objeto
            Vector3 nuevaPosicion = transform.position + new Vector3(direccionAleatoria.x, direccionAleatoria.y, 0f) * velocidadMovimiento * Time.deltaTime;

            // Mueve el objeto hacia la nueva posici�n
            transform.position = nuevaPosicion;

            // Pausa la coroutine por un corto periodo antes de obtener una nueva direcci�n aleatoria
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }
}
