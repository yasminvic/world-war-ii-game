using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Explosion")]
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private Clip explosionClip;

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
        
    }
}
