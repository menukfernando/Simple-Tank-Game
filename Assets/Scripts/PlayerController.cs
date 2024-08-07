using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Text ScoreText;
    float xInput;

    Rigidbody2D rb;
    SpriteRenderer sr;
    int score = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        FlipTank();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * xInput * moveSpeed;
    }

    void FlipTank()
    {
        if(xInput < 0)
        {
            sr.flipX = true;
        }else if(xInput > 0)
        {
            sr.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            score++;

            ScoreText.text = "Score: "+score.ToString();
        }

        if (score == 4)
        {
            ScoreText.text = "Good Job";
        }

        if (score == 4)
        {
            Invoke("Restart", 2f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Tank Game");
    }
}
