using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < 6)
            {
                // Obtiene la direcci�n hacia el jugador
                Vector2 direction = (player.transform.position - transform.position).normalized;

                timer += Time.deltaTime;

                if (timer > 2)
                {
                    timer = 0;
                    shoot();
                }
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, transform.rotation);
    }
}
