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
    private float finishTime;

    void Awake()
    {
        int randomDelay = Random.Range(delaySpawnMin, delaySpawnMax);

        if (finishTime > 0)
        {
            InvokeRepeating(nameof(Spawn), initialDelay, randomDelay);
        }

    }

    void Spawn()
    {

        float count = 3f;
        foreach (var prefab in spawnPrefabs)
        {
            Instantiate(prefab, 
                new Vector2
                (
                    transform.position.x - count,
                    transform.position.y - count
                ), 
                transform.rotation);

            count-=1;


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
        Debug.Log(finishTime);
    }
}
