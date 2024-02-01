using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetFloat("Insanity") >= 4f)
        {
            Debug.Log("asdaw");
            SceneManager.LoadScene("Die");
        }
    }
}
