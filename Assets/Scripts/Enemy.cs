using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitsToDie = 10;
    private int hits = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            hits++;
            Debug.Log("Enemy hit: " + hits);

            GameManager.instance.AddScore();

            Destroy(other.gameObject);

            if (hits >= hitsToDie)
            {
                Destroy(gameObject);
            }
        }
    }
}