using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Explosion")]
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private Clip explosionClip;

    [Header("Shoot")]
    [SerializeField]
    private GameObject shootPrefab;
    [SerializeField]
    private GameObject flashPrefab;
    [SerializeField]
    private Clip shootClip;
    [SerializeField]
    private float initialDelay;
    [SerializeField]
    private Range delayShoot;
    [SerializeField]
    private GameObject pivotShoot;

    [SerializeField]
    private GameObject pivotPlayer;
    [SerializeField]
    private float distanciaShoot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shoot"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            //ExplosionManagerFx.Instance.Create(gameObject.transform.position, gameObject.transform.rotation);

            Instantiate(explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
            AudioManager.PlayClip(explosionClip);

        }

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }

    private void Awake()
    {
        int delay = Random.Range(delayShoot.min, delayShoot.max);
        InvokeRepeating(nameof(Shoot), initialDelay, delay);
    }

    private void Shoot()
    {
        if(pivotPlayer.transform.position.x - gameObject.transform.position.x < distanciaShoot)
        {
            Instantiate(flashPrefab, pivotShoot.transform.position, pivotShoot.transform.rotation);
            Instantiate(shootPrefab, pivotShoot.transform.position, pivotShoot.transform.rotation);
            AudioManager.PlayClip(shootClip);
        }
        

    }
}
