﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Grabbable {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Stomach>())
        {
            //Do damage
        }
    }
}
