﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInvisible : MonoBehaviour {

    public int MinimumPosition;
    public int MaximumPosition;

    void OnBecameInvisible()
    {
        Debug.Log("Became invisible!");
        transform.Translate(- Random.Range(this.MinimumPosition, this.MaximumPosition), 0, 0);
    }
}
