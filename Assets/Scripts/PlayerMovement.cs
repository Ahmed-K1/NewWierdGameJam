using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    [Header("Bounce Effect")]
    public float bounceSpeed = 10f;
    public float bounceAmount = 0.05f;
    private float bounceTimer = 0f;
    private Vector3 originalScale;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        bool isMoving = moveInput.x != 0 || moveInput.y != 0;
        if (isMoving)
        {
            bounceTimer += Time.deltaTime * bounceSpeed;
            float scaleY = originalScale.y + Mathf.Sin(bounceTimer) * bounceAmount;
            transform.localScale = new Vector3(originalScale.x, scaleY, originalScale.z);
        }
        else
        {
            bounceTimer = 0f;
            transform.localScale = originalScale;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }
}