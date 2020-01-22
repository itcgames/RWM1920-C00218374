using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFilter
{
    public static bool getBubble()
    {
        if (GameObject.Find("Bubble") != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Vector3 getPosition()
    {
        GameObject bubble = GameObject.FindGameObjectWithTag("bubble");
        return bubble.transform.position;
    }
}
