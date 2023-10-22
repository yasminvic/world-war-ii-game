using UnityEngine;
using UnityEngine.SceneManagement;
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
    private GameObject flashPrefab;
    [SerializeField]
    private Clip shootClip;
    [SerializeField]
    private GameObject pivot;

    [Header("Damage")]
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int damageHealth;
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private GameObject shootEnemy;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject explosionPrefab;

    [Header("Scene Dead")]
    [SerializeField]
    private string nameSceneDead;

    [Header("Scene Win")]
    [SerializeField]
    private string nameSceneWin;

    private int currentHealth;
    private int _score = 0;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

        //controla a movimentação
        Move();
        
        //atirar
        Shoot();

        //limite da tela
        ApplyBounds();

        Dead();
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

        Instantiate(flashPrefab, pivot.transform.position, pivot.transform.rotation);
        Instantiate(shootPrefab, pivot.transform.position, pivot.transform.rotation);
        AudioManager.PlayClip(shootClip);
    }

    public void Dead()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(nameSceneDead);
        }
    }

    public void Win()
    {
        SceneManager.LoadScene(nameSceneWin);
    }

    public void TakeDamage(int damage)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            _score++;
            AudioManager.PlayClip(coinSound);
            Destroy(collision.gameObject);
            FindObjectOfType<Score>().UpdateScore(_score);
            
        }

        //HealthBar
        if(collision.CompareTag("Shoot Left") || collision.CompareTag("Enemy"))
        {
            TakeDamage(damageHealth);
        }

        if (collision.CompareTag("Flag"))
        {
            Win();
        }
    }
}
