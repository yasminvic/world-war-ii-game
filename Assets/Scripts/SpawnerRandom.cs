using UnityEngine;

public class SpawnerRandom : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField]
    private GameObject spawnPrefab;

    [Header("Coordenadas X")]
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;

    [Header("Coordenadas Y")]
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;

    [Header("Delay")]
    [SerializeField]
    private float initialDelay;
    [SerializeField]
    private float spawnDelay;

    void Awake()
    {
        InvokeRepeating(nameof(Spawn), initialDelay, spawnDelay);
    }

    void Spawn()
    {
        var randomX = Random.Range(minX, maxX);
        var randomY = Random.Range(minY, maxY);

        var position = new Vector3
            (
               transform.position.x + randomX,
               transform.position.y + randomY
            );

        Instantiate(spawnPrefab, position, transform.rotation);
    }
}
