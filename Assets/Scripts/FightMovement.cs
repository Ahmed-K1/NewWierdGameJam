using UnityEngine;

public class FightMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private float verticalInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.instance.gameEnded) return;

        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (GameManager.instance.gameEnded)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = new Vector2(0, verticalInput * moveSpeed);
    }
}