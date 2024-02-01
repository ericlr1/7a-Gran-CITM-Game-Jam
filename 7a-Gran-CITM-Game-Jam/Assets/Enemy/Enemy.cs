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
        // Obt�n la referencia al componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Aseg�rate de que el AudioSource est� configurado correctamente
        if (audioSource == null)
        {
            Debug.LogError("El componente AudioSource no est� adjunto al objeto.");
        }
        else
        {
            // Aseg�rate de que se haya asignado un clip de audio
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
                Debug.Log("Sonido Da�o");
            }

            // Aqu� puedes agregar cualquier l�gica adicional cuando el enemigo muere
            Destroy(gameObject);

            
        }
    }
}