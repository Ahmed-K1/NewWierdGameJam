using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 8f;
    Transform player;
    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 6f);
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 dir = (player.position - transform.position).normalized;
        rb.linearVelocity = dir * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy orb hit: " + other.tag); // ?? DEBUG

        if (other.CompareTag("Player"))
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
        }
    }
}