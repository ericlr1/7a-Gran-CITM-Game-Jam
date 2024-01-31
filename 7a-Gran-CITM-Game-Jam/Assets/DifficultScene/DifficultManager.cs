using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultManager : MonoBehaviour
{
    public void EasyScene()
    {
        SceneManager.LoadScene("DifficultEasyScene");
    }
}
