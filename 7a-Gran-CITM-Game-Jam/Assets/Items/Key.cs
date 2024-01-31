using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (door != null)
            {
                door.GetComponent<Door>().UnlockDoor();
                gameObject.SetActive(false);
            }
        }
    }
}
