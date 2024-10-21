using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float jumpSpeed;
    public GameManager game;
    public GameObject endScreen;
    Rigidbody2D rb;
    AudioSource[] audioSources;
    CircleCollider2D cl;
    bool hitPlayed = false;
    bool fallPlayed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = 0;
        audioSources = GetComponents<AudioSource>();
        cl = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hitPlayed)
        {
            transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * 5f);
            if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)))
            {
                game.gameStart();
                rb.velocity = new Vector2(0, jumpSpeed);
                rb.simulated = true;
                Pipe.speed = 4;
                audioSources[0].Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!hitPlayed)
        {
            audioSources[1].Play();
            hitPlayed = true;
        }
        Pipe.speed = 0;
        if (other.gameObject.name=="Ground")
        {
            rb.simulated = false;

            Vector3 pos = transform.position;
            pos.y = -3.63f;
            transform.position = pos;
            game.gameEnd();
        }
        if (other.gameObject.name.Contains("Pipe"))
        {
            if (Math.Abs(other.gameObject.transform.position.x - transform.position.x) < 0.9)
            {
                if (other.gameObject.transform.position.y < transform.position.y)
                {
                    rb.simulated = false;
                    game.gameEnd();
                }
                else
                {
                    audioSources[2].Play();
                }
            }
            else if (other.transform.position.x - transform.position.x > 0.9 && !fallPlayed)
            {
                cl.offset = new Vector2(-0.4f, 0);
                audioSources[2].Play();
                fallPlayed = true;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("PipePair")&&!hitPlayed)
        {
            game.score++;
            audioSources[3].Play();
        }
    }
}
