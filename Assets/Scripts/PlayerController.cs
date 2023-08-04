using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D RB;

    private float moveInput;
    private float speed = 15f;

    private float topScore = 0.0f;

    private float currentHighScore;
    private float sessionScore;

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Score();

        if (moveInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

    }   

    
    void FixedUpdate() 
    {
        moveInput = Input.GetAxis("Horizontal");
        RB.velocity = new Vector2 (moveInput * speed, RB.velocity.y);
    }

    public void Score()
    {
        if (RB.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        scoreText.text = Mathf.Round(topScore * 20).ToString();

        UpdateHighScore();

    }

    public void UpdateHighScore()
    {
        sessionScore = float.Parse(scoreText.text);
        currentHighScore = float.Parse(StateNameController.Score);

        if (sessionScore > currentHighScore)
        {
            StateNameController.Score = scoreText.text;
        }
    }

}
