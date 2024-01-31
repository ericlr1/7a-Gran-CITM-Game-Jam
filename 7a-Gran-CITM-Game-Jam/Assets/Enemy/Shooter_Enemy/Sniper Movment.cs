using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMovment : MonoBehaviour
{
    public float radioMovimiento = 5f;
    public float velocidadMovimiento = 2f;

    void Start()
    {
        // Llama a la función para iniciar el movimiento aleatorio
        MoverAleatoriamente();
    }

    void Update()
    {
        // Puedes agregar otros comportamientos o lógica aquí si es necesario
    }

    void MoverAleatoriamente()
    {
        // Obtiene una posición aleatoria dentro de un círculo unitario y la escala por el radio deseado
        Vector2 direccionAleatoria = Random.insideUnitCircle.normalized * radioMovimiento;

        // Establece la posición inicial del objeto en la posición aleatoria dentro del radio
        transform.position = new Vector3(direccionAleatoria.x, direccionAleatoria.y, 0f);

        // Inicia la coroutine para el movimiento suave
        StartCoroutine(MoverSuavemente());
    }

    System.Collections.IEnumerator MoverSuavemente()
    {
        while (true)
        {
            // Obtiene una dirección aleatoria en cada frame
            Vector2 direccionAleatoria = Random.insideUnitCircle.normalized;

            // Calcula la nueva posición del objeto
            Vector3 nuevaPosicion = transform.position + new Vector3(direccionAleatoria.x, direccionAleatoria.y, 0f) * velocidadMovimiento * Time.deltaTime;

            // Mueve el objeto hacia la nueva posición
            transform.position = nuevaPosicion;

            // Pausa la coroutine por un corto periodo antes de obtener una nueva dirección aleatoria
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }
}
