using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public Sprite north, south, east, west;
    public Sprite northEast, northWest, southEast, southWest;
    public Sprite idleSprite; // esim. south seisten paikallaan

    private SpriteRenderer sr;
    private PlayerMovement movement;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h == 0 && v == 0) return; // pysyy viimeisimmässä spritessä paikallaan

        if (h > 0 && v > 0) sr.sprite = northEast;
        else if (h > 0 && v < 0) sr.sprite = southEast;
        else if (h < 0 && v > 0) sr.sprite = northWest;
        else if (h < 0 && v < 0) sr.sprite = southWest;
        else if (h > 0) sr.sprite = east;
        else if (h < 0) sr.sprite = west;
        else if (v > 0) sr.sprite = north;
        else if (v < 0) sr.sprite = south;
    }
}