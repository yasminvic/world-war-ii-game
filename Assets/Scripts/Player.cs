using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [Header("Move")]
    [SerializeField]
    private float moveSpeed = 0.1f;

    [Header("Bounds")]
    [SerializeField]
    private BoxCollider2D playerBounds;

    [Header("Sound Effects")]
    [SerializeField]
    private Clip coinSound;

    [Header("Shoot")]
    [SerializeField]
    private GameObject shootPrefab;
    [SerializeField]
    private Clip shootClip;
    [SerializeField]
    private GameObject pivot;

    private int _score = 0;

    void Update()
    {
        //controla a movimentação
        Move();

        //limite da tela
        //ApplyBounds();

        //atirar
        Shoot();
    }

    void Move()
    {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");

        var move = new Vector3
        (
            h * moveSpeed * Time.deltaTime,
            v * moveSpeed * Time.deltaTime
        );


        transform.Translate(move);
    }

    void ApplyBounds()
    {
        var minX = -playerBounds.bounds.extents.x + playerBounds.offset.x;
        var maxX = playerBounds.bounds.extents.x + playerBounds.offset.x;

        var minY = -playerBounds.bounds.extents.y + playerBounds.offset.y;
        var maxY = playerBounds.bounds.extents.y + playerBounds.offset.y;

        //define a posição do player
        transform.position = new Vector3(
            //vai garantir que o valor de x e y tenha um min e max
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
        );
    }

    public void Shoot()
    {
        if (!Input.GetButtonDown("Fire1"))
        {
            return;
        }

        Instantiate(shootPrefab, pivot.transform.position, pivot.transform.rotation);
        AudioManager.PlayClip(shootClip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            _score++;
            AudioManager.PlayClip(coinSound);
            Destroy(collision.gameObject);
            Debug.Log($"score: {_score}");
            FindObjectOfType<Score>().UpdateScore(_score);
            
        }
    }
}
