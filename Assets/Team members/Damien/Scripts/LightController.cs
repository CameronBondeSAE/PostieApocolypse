﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light;

    public bool blindPlayer;
    public bool flashOn;
    

    private void Start()
    {
        blindPlayer = false;
        flashOn = false;
    }

    private void FixedUpdate()
    {
       
            if (flashOn)
            {
                light.intensity = 200000000f;
                flashOn = false;
            }

            if (!flashOn)
            {
                light.intensity = 0.2f;
            }
        
        
        
    }
}