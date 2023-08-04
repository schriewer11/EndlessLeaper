using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destory : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject boostPlatformPrefab;
    public GameObject cloudPrefab;
    public GameObject enemy; 

    private GameObject newPlatform;

    float cloudChangeSides = 1;

    int randomNum;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Platforms
    public void OnTriggerEnter2D(Collider2D collision)
    {
        float spawnWidth = Random.Range(-9f, 9f);
        float spawnHeight = player.transform.position.y + (14 + Random.Range(0.2f, 1.0f));

        switch(collision.gameObject.tag)
        {
            case "platform":
                handlePlatformCollision(collision, spawnWidth, spawnHeight);
                break;
            case "boostPlatform":
                handleBoostPlatformCollision(collision, spawnWidth, spawnHeight);
                break;
            case "cloud":
                handleCloudCollision(collision);
                break;
            case "enemy":
                collision.gameObject.transform.position = new Vector2(spawnWidth, spawnHeight * 5);
                break;
            default:
                break;
        }
        
    }

    public void handlePlatformCollision(Collider2D collision, float spawnWidth, float spawnHeight)
    {
        randomNum = Random.Range(1, 14);
        if (randomNum == 1 || randomNum == 7)
        {
            Destroy(collision.gameObject);
            Instantiate(boostPlatformPrefab, new Vector2(spawnWidth, spawnHeight), Quaternion.identity);
        }
        else
        {
            collision.gameObject.transform.position = new Vector2(spawnWidth, spawnHeight);
        }
    }

    public void handleBoostPlatformCollision(Collider2D collision, float spawnWidth, float spawnHeight)
    {
        randomNum = Random.Range(1, 14);
        if (randomNum == 1 || randomNum == 7)
        {
            collision.gameObject.transform.position = new Vector2(spawnWidth, spawnHeight);
        }
        else
        {
            Destroy(collision.gameObject);
            newPlatform = Instantiate(platformPrefab, new Vector2(spawnWidth, spawnHeight), Quaternion.identity);
            if (randomNum == 3 || randomNum == 5 || randomNum == 9 || randomNum == 11 || randomNum == 13)
            {
                Instantiate(enemy, new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y + 3), Quaternion.identity);
            }
        }
    }

    public void handleCloudCollision(Collider2D collision)
    {
        // Alternate sides where cloud spawns
        if (cloudChangeSides == 1)
        {
            collision.gameObject.transform.position = new Vector2(Random.Range(-10.5f, -13.0f), player.transform.position.y + (14 + Random.Range(3f, 6f)));
            cloudChangeSides -= 1;
        }
        else if (cloudChangeSides == 0)
        {
            collision.gameObject.transform.position = new Vector2(Random.Range(10.5f, 13.0f), player.transform.position.y + (14 + Random.Range(3f, 6f)));
            cloudChangeSides += 1;
        }
    }

}
