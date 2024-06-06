using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Vector2 JumpForce;
    public Rigidbody2D rb2D;

    public int Points;

    public static bool GameOver;
    public static bool HasStarted;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == true)
            return;

        if (Input.GetButtonDown("Jump"))
        {
            if (HasStarted == false)
            {
                rb2D.gravityScale = 1;
                HasStarted = true;
            }

            rb2D.AddForce(JumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PointZone"))
        {
            Points++;
        }
    }
}
