using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    public int salud = 100;
    public AudioClip sonidoMuerte;  // Asigna el clip de audio desde el Inspector
    public AudioSource audioSource;

    void Start()
    {
        // Obtén la referencia al componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Asegúrate de que el AudioSource esté configurado correctamente
        if (audioSource == null)
        {
            Debug.LogError("El componente AudioSource no está adjunto al objeto.");
        }
        else
        {
            // Asegúrate de que se haya asignado un clip de audio
            if (sonidoMuerte == null)
            {
                Debug.LogError("No se ha asignado un clip de audio para la muerte del enemigo.");
            }
        }
    }

    public void RecibirDano(int cantidad)
    {
        salud -= cantidad;

        // Verifica si la salud es menor o igual a cero para "matar" al enemigo
        if (salud <= 0)
        {
            // Reproduce el sonido de muerte si hay un clip de audio asignado
            if (sonidoMuerte != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoMuerte);
                Debug.Log("Sonido Daño");
            }

            // Aquí puedes agregar cualquier lógica adicional cuando el enemigo muere
            Destroy(gameObject);

            
        }
    }
}