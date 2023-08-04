using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverBoxController : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveGameOverBox();
    }

    public void moveGameOverBox()
    {
        // If the player moves up, move the 
        if (playerRB.velocity.y > 0)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 25f, transform.position.z);
        }
    }

}
