﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag.Equals("Object"))
        {
            Debug.Log("object");
        }
        if (tag.Equals("Obstacle"))
        {
            Debug.Log("obstacle");
        }
    }
}
