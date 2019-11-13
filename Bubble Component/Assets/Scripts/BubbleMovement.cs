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

    public string playerName;
    GameObject player;

    //move the bubble up 
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed);
        startTimer = true;
    }

    // Once the destination is reached destroy the bubble
    void Update()
    {
        if (startTimer)
        {
            time();
        }
        if (timer >= maxTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != playerName)
        {
            Destroy(gameObject);
        }
        else
        {
            player = other.gameObject;
            player.transform.SetParent(this.transform);
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.transform.localPosition = this.transform.position;
        }
    }

    //when the bubble is destroyed instatiate particle effect
    private void OnDestroy()
    {
        player.transform.SetParent(null);
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        player.GetComponent<Collider2D>().enabled = true;
        Instantiate(particles, transform.position, transform.rotation);
    }

    private void time()
    {
        timer += Time.deltaTime;     
    }
}
