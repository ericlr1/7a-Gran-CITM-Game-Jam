using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 5f;

    private void Start()
    {
        // Llama al m�todo 'SpawnPrefab' cada 'spawnInterval' segundos.
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    private void SpawnPrefab()
    {
        // Instancia el prefab en la posici�n del Spawner.
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}
