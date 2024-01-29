using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 5f;
    public int numberOfEnemies = 5;
    public float spawnRadius = 5f;
    public float spawnDistance = 10f;

    private GameObject player;  // Referencia al GameObject del jugador

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Llama al método 'SpawnPrefab' cada 'spawnInterval' segundos.
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    private void SpawnPrefab()
    {
        // Verifica si el jugador está dentro de la distancia de spawn.
        if (player != null && Vector3.Distance(transform.position, player.transform.position) <= spawnDistance)
        {
            // Utiliza un bucle for para instanciar 'numberOfEnemies' enemigos.
            for (int i = 0; i < numberOfEnemies; i++)
            {
                // Genera un ángulo aleatorio en radianes.
                float randomAngle = Random.Range(0f, 360f);

                // Convierte el ángulo a radianes.
                float angleInRadians = randomAngle * Mathf.Deg2Rad;

                // Calcula las coordenadas polares y ajusta por el radio.
                float x = spawnRadius * Mathf.Cos(angleInRadians);
                float y = spawnRadius * Mathf.Sin(angleInRadians);

                // Calcula la posición final sumando las coordenadas polares al spawner.
                Vector3 spawnPosition = transform.position + new Vector3(x, y, 0f);

                // Instancia el prefab en la posición calculada.
                Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }
}
