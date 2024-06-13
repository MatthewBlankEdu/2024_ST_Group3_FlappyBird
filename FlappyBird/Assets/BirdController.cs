using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public Vector2 JumpForce;
    public Rigidbody2D rb2D;
    public GameObject GameOverPanel;
    public TextMeshProUGUI PointsTextField;

    public AudioSource audioSource;

    public AudioClip hitSFX;
    public AudioClip scoreSfX;
    public AudioClip jumpSFX;

    public Animator animator;

    public int Points;

    public static bool GameOver;
    public static bool HasStarted;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        HasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        PointsTextField.text = Points.ToString();

        if (GameOver == true)
            return;

        if (Input.GetButtonDown("Jump"))
        {
            if (HasStarted == false)
            {
                rb2D.gravityScale = 1;
                HasStarted = true;
            }

            animator.SetTrigger("FlapWings");

            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(JumpForce, ForceMode2D.Impulse);

            audioSource.clip = jumpSFX;
            audioSource.Play();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver = true;
        GameOverPanel.SetActive(true);

        audioSource.clip = hitSFX;
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PointZone"))
        {
            audioSource.clip = scoreSfX;
            audioSource.Play();

            Points++;
        }
    }
}
