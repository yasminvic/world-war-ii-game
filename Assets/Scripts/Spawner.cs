using UnityEngine;
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

    void Awake()
    {
        int randomDelay = Random.Range(delaySpawnMin, delaySpawnMax);
        InvokeRepeating(nameof(Spawn), initialDelay, randomDelay);
    }

    void Spawn()
    {

        float count = 9f;
        foreach (var prefab in spawnPrefabs)
        {
            Instantiate(prefab, 
                new Vector2
                (
                    transform.position.x - count,
                    transform.position.y
                ), 
                transform.rotation);

            count-=3;
        }
        
    }
}
