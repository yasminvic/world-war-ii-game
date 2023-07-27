using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[Header("Prefabs")]
    //[SerializeField]
    //private GameObject explosionPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shoot"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            ExplosionManagerFx.Instance.Create(gameObject.transform.position, gameObject.transform.rotation);
            //Instantiate(explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
        
    }
}
