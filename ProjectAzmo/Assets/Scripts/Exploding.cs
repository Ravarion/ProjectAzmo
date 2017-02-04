using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : Grabbable {

    public GameObject explosionFab;
    bool primed = false;

    public override bool ReleaseTrigger()
    {
        primed = true;
        return base.ReleaseTrigger();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(primed)
        {
            Instantiate(explosionFab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
