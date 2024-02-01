using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Creazy : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;
    private bool isPlaying = false;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        PlaySound();
    }
    private void PlaySound() 
    {
        if (animator.GetFloat("Insanity") <= 3)
        {
            if (!isPlaying) { 
            StartCoroutine(playOn());
            }
        }
    }
    IEnumerator playOn()
    {
        isPlaying = true;
        audioSource.Play();
        Debug.Log("Pedito");
        yield return new WaitForSeconds(360*Time.fixedDeltaTime);
        isPlaying = false;
    }
}
