using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreFromSession;

    public TextMeshProUGUI scoreToDisplay;
    Rigidbody2D playerRB;
    

    // Start is called before the first frame update
    void Start()
    {
        var scoreFromSessionText = scoreFromSession.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (gameObject.tag == "enemy")
            {
                // If the player is on top of the enemy, the enemy gets destroyed
                if (collision.gameObject.transform.position.y > gameObject.transform.position.y)
                {
                    Debug.Log("Enemy dies");
                    gameObject.transform.position = new Vector2(Random.Range(-9f, 9f), collision.transform.position.y * 15);
                }
                else
                {
                    Debug.Log("Player dies");
                    collision.gameObject.transform.position = new Vector2(0, 0);
                    scoreToDisplay.text = scoreFromSession.text.ToString();
                    gameOverScreen.SetActive(true);
                }
            } 
            else
            {
                scoreToDisplay.text = scoreFromSession.text.ToString();
                gameOverScreen.SetActive(true);
                Debug.Log("Player should be destoryed");
            }
        }
    }

    /*public void GameOver(Collider2D collision)
    {
        
        switch (collision.gameObject.tag)
        {
            case "player":
                scoreToDisplay.text = scoreFromSession.text.ToString();
                gameOverScreen.SetActive(true);
                Debug.Log("Player should be destoryed");
                break;
            case "enemy":

                break;
            default:
                break;
        }
    }*/

    

}
