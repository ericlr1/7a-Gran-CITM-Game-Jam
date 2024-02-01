using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void CargarOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void CargarPlay()
    {
        SceneManager.LoadScene("DifficultScene");
    }
    public void CargarDifficultyEasy()
    {
        SceneManager.LoadScene("DifficultEasy");
    }
    public void CargarCreditos()
    {
        SceneManager.LoadScene("Credits");
    }

    //public void CargarDifficultyNormal()
    //{
    //    SceneManager.LoadScene("DifficultNormalScene");
    //}
    //public void CargarDifficultyHard()
    //{
    //    SceneManager.LoadScene("DifficultHardScene");
    //}
    public void Exit()
    {
        Application.Quit();
    }


}
