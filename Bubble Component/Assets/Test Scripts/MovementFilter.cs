using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFilter
{
    public static Vector3 getPosition()
    {
        GameObject bubble = GameObject.FindGameObjectWithTag("bubble");
        return bubble.transform.position;
    }
}
