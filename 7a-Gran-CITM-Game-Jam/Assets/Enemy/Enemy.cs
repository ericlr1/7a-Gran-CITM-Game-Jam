using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int salud = 100;

    public void RecibirDano(int cantidad)
    {
        Debug.Log("Pedrito");
        salud -= cantidad;

        // Verifica si la salud es menor o igual a cero para "matar" al enemigo
        if (salud <= 0)
        {
            // Aquí puedes agregar cualquier lógica adicional cuando el enemigo muere
            Destroy(gameObject);
        }
    }
}
