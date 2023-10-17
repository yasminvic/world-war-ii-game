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
        float speed;
        if (PauseMenu.IsPaused)
        {
            speed = 0;
        }
        else
        {
            speed = moveSpeed;
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
