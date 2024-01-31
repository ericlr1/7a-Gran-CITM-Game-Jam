using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    public int salud = 100;

    public AudioSource source;
    public AudioClip clipSource;

    public void RecibirDano(int cantidad)
    {
        
        salud -= cantidad;

        // Verifica si la salud es menor o igual a cero para "matar" al enemigo
        if (salud <= 0)
        {
            // Aqu� puedes agregar cualquier l�gica adicional cuando el enemigo muere
            Destroy(gameObject);
            source.PlayOneShot(clipSource);
            Debug.Log("Sonido Da�o");
        }
    }
}
