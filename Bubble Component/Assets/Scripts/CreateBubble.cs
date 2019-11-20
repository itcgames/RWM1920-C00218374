using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBubble : MonoBehaviour
{
    public GameObject bubble;
    public string playerTag;

    public Vector3 bubblePosition;
    Quaternion rotation = new Quaternion();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            Instantiate(bubble, bubblePosition, rotation);
        }
    }
}
