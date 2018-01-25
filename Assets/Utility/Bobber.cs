﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    [SerializeField] float strength = 5;
    [SerializeField] float speed = 2;


    void Start()
    {

    }


    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0 + Mathf.Sin(Time.time * speed) * strength, transform.localPosition.z);
    }

}
