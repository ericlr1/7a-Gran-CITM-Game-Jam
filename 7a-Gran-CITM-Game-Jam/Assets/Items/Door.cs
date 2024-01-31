using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private bool doorLocked = true;

    void FixedUpdate()
    {
        if (doorLocked == false)
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void UnlockDoor()
    {
        source.PlayOneShot(clip);
        Debug.Log("UnlockDoor");
        doorLocked = false;
    }
}
