using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Tilemaps;
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
    private AudioSource coinSound;

    private int _score = 0;


    [Header("Shoot")]
    [SerializeField]
    private GameObject shootPrefab;
    [SerializeField]
    private GameObject pivot;
    void Update()
    {
        //controla a movimentação
        Move();

        //limite da tela
        ApplyBounds();

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
            v * 0
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colidiu");
        if (collision.CompareTag("Coin"))
        {
            _score++;
            coinSound.Play();
            Destroy(collision.gameObject);
            FindObjectOfType<Score>().UpdateScore(_score);
        }
    }
}
