using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private AudioSource jumpSoundSource;
    //public AudioClip jumpSound;
    float leapHeight = 600f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpSoundSource = GetComponent<AudioSource>();
        if (collision.gameObject.tag == "player")
        {
            // if we're on top of the platform, the player will jump on top of it // and don't apply this to destroyer
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                if (this.tag == "boostPlatform")
                {
                    leapHeight = 1000f;
                }
                jumpSoundSource.Play();
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * leapHeight);

            }
        }
    }
        
}
