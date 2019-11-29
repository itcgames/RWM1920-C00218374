using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public GameObject particles;
    public float speed;

    bool startTimer = false;
    float timer = 0;
    public float maxTime;
    float destroyTime;

    public string playerTag;
    GameObject player;

    public Vector3 bubbleSize;
    public Vector3 blowSpeed;

    private Animator anim;

    //move the bubble up 
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed);
        anim = GetComponent<Animator>();
        startTimer = true;
        
    }

    // Once the destination is reached destroy the bubble
    void Update()
    {
        //time taken before bubble pops
        if (startTimer)
        {
            time();
        }
        if (timer >= maxTime)
        {
            anim.SetBool("Pop", true);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bubblePop"))
            {
                Instantiate(particles, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        //blowing up the bubble
        if (transform.localScale != bubbleSize)
        {
            transform.localScale += blowSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.transform.childCount <= 0)
        {
            if (other.tag != playerTag && other.tag != "Bubble")
            {
                anim.SetBool("Pop", true);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("bubblePop"))
                {
                    Instantiate(particles, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
            else if (other.tag != "Bubble")
            {
                player = other.gameObject;
                player.transform.SetParent(this.transform);
                player.GetComponent<Rigidbody2D>().isKinematic = true;
                player.transform.localPosition = this.transform.position;
            }
        }
        else
        {
            return;
        }
    }

    //when the bubble is destroyed instatiate particle effect
    private void OnDestroy()
    {
        player.transform.SetParent(null);
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        player.GetComponent<Collider2D>().enabled = true;
    }

    private void time()
    {
        timer += Time.deltaTime;     
    }
}
