using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMovment : MonoBehaviour
{
    public float radioMovimiento = 5f;
    public float velocidadMovimiento = 2f;
    public float intervaloCambioPosicion = 3f;

    void Start()
    {
        // Llama a la funci�n para iniciar el movimiento aleatorio cada cierto intervalo
        InvokeRepeating("MoverAleatoriamente", 0f, intervaloCambioPosicion);
    }

    void Update()
    {
        // Puedes agregar otros comportamientos o l�gica aqu� si es necesario
    }

    void MoverAleatoriamente()
    {
        // Obtiene una posici�n aleatoria dentro de un c�rculo unitario y la escala por el radio deseado
        Vector2 direccionAleatoria = Random.insideUnitCircle.normalized * radioMovimiento;

        // Establece la posici�n del objeto en la posici�n aleatoria dentro del radio
        transform.position = direccionAleatoria;
    }
}
