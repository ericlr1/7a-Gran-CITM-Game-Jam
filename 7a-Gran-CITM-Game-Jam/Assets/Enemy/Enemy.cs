using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    public int salud = 100;
    public GameObject particulasColision;

    public void RecibirDano(int cantidad)
    {
        salud -= cantidad;

        if (salud <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisi�n es con un objeto que tenga el tag "Bala"
        if (collision.gameObject.CompareTag("Bala"))
        {
            // Activa el sistema de part�culas si est� asignado
            if (particulasColision != null)
            {
                Instantiate(particulasColision, transform.position, Quaternion.identity);
            }

            // Aqu� puedes agregar cualquier l�gica adicional cuando colisiona con una bala
        }
    }
}