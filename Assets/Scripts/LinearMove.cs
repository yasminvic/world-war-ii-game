using UnityEngine;

public class LinearMove : MonoBehaviour
{
    [Header("Move")]
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Vector2 direction;

    void Update()
    {

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
