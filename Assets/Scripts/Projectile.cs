using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �L� tuhoa enemy� t��ll�
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("EnemyProjectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}