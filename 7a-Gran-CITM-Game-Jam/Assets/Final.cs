using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisionó es el jugador
        if (other.CompareTag("Player"))
        {
            // Cambia a la escena especificada
            SceneManager.LoadScene("Win");
        }
    }
}
