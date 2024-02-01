using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Menu : MonoBehaviour
{
    private bool juegoPausado = false;
    public GameObject objetoAActivarDesactivar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            juegoPausado = !juegoPausado;
            GestionarPausaReanudacion();
            // Alternar entre activar y desactivar
            if (objetoAActivarDesactivar != null)
            {
                if (objetoAActivarDesactivar.activeSelf)
                {
                    DesactivarObjeto();
                }
                else
                {
                    ActivarObjeto();
                }
            }
        }
    }


    void ActivarObjeto()
    {
        // Activa el objeto si no está activo
        if (objetoAActivarDesactivar != null && !objetoAActivarDesactivar.activeSelf)
        {
            objetoAActivarDesactivar.SetActive(true);
        }
    }

    public void DesactivarObjeto()
    {
        // Desactiva el objeto si está activo
        if (objetoAActivarDesactivar != null && objetoAActivarDesactivar.activeSelf)
        {
            objetoAActivarDesactivar.SetActive(false);
        }
    }
    public void GestionarPausaReanudacion()
    {
        if (juegoPausado)
        {
            PausarJuego();
        }
        else
        {
            ReanudarJuego();
        }
    }

    void PausarJuego()
    {
        Time.timeScale = 0f;  // Pausar el tiempo
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1f;  // Reanudar el tiempo
    }
}