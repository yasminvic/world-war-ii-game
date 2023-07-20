using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject[] spawnPrefabs;

    [Header("Delay")]
    [SerializeField]
    private float delaySpawn;

    [SerializeField]
    private float initialDelay;

    void Awake()
    {
        InvokeRepeating(nameof(Spawn), initialDelay, delaySpawn);
    }

    void Spawn()
    {
        //float count = 4f;
        foreach (var prefab in spawnPrefabs)
        {
            Instantiate(prefab, transform.position, transform.rotation);

        }
        
    }
}
