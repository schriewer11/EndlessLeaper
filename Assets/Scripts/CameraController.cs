using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float followSpeed = 1f;
    private float highestPoint;
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
        moveCamera();
    }

    public void moveCamera()
    {
        if (playerRB.velocity.y > 0 && player.transform.position.y > highestPoint)
        {
            highestPoint = transform.position.y;
            
            Vector3 newPos = new Vector3(0f, player.transform.position.y + 10f, -10f);
            transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }
}
