using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float destructTimer;

    private void Start()
    {
        Cannon[] cannons = FindObjectsOfType<Cannon>();
        foreach(Cannon cannon in cannons)
        {
            if(Vector3.Distance(cannon.transform.position, transform.position) < .5f)
            {
                Destroy(cannon.gameObject);
            }
        }
    }

    private void Update()
    {
        destructTimer -= Time.deltaTime;
        if(destructTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
