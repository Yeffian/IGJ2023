using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float repeatRate;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnEnemy()
    {
        Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
        Instantiate(enemy, spawnpoint.position, spawnpoint.rotation);
        Debug.Log(spawnpoint.gameObject.name);
    }
}
