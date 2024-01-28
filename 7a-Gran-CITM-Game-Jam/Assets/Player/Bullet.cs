using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float lifeTime = 2f; // Tiempo de vida de la bala

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); // Destruye la bala después de lifeTime segundos
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si la bala colisiona con algo, se destruye
        Destroy(gameObject);
    }
}
