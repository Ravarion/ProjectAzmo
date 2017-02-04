using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : Grabbable {

    GameObject explosionFab;
    bool primed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(primed)
        {
            Instantiate(explosionFab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
