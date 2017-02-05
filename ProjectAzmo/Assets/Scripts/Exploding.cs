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
            Explode();
        }
    }

    public void Explode()
    {
        GameObject explosion = Instantiate(explosionFab, transform.position, transform.rotation);
        explosion.GetComponent<Explosion>().origin = gameObject;
        Destroy(gameObject);
    }
}
