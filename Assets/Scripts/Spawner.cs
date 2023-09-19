using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject[] spawnPrefabs;

    [Header("Delay")]
    [SerializeField]
    private int delaySpawnMax;
    [SerializeField]
    private int delaySpawnMin;

    [SerializeField]
    private float initialDelay;

    [SerializeField]
    private Range distanciamento;

    [SerializeField]
    private float finishTime;

    void Awake()
    {
        int randomDelay = Random.Range(delaySpawnMin, delaySpawnMax);

        InvokeRepeating(nameof(Spawn), initialDelay, randomDelay);

    }

    void Spawn()
    {
        foreach (var prefab in spawnPrefabs)
        {
            int x = Random.Range(distanciamento.min, distanciamento.max);
            Instantiate(prefab, 
                new Vector2
                (
                    transform.position.x - x,
                    transform.position.y - x
                ), 
                transform.rotation);

        }

        DestroySpawner();
    }

    void DestroySpawner()
    {
        if (finishTime < 0)
        {
            Destroy(gameObject);
        }
        finishTime -= 1;
    }
}
