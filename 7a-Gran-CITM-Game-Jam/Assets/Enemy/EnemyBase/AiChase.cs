using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    public float speed;
    public float range;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Player player = PlayerManager.Instance.Player;

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < range)
        {
            // Mueve al enemigo hacia el jugador en el plano xy
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            // Establece la posición en el eje z a -2
            transform.position = new Vector3(transform.position.x, transform.position.y, -2f);
        }
    }
}
