using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Vector2 JumpForce;
    public Rigidbody2D rb2D;
    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb2D.AddForce(JumpForce, ForceMode2D.Impulse);
        }
    }
}
