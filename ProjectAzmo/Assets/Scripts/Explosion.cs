using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject origin;
    public float destructTimer;

    private void Start()
    {
        Cannon[] cannons = FindObjectsOfType<Cannon>();
        foreach(Cannon cannon in cannons)
        {
            if(Vector3.Distance(cannon.transform.position, transform.position) < .5f)
            {
                cannon.Destruct();
            }
        }
        Exploding[] explodings = FindObjectsOfType<Exploding>();
        foreach(Exploding exploding in explodings)
        {
            if (Vector3.Distance(exploding.transform.position, transform.position) < .5f && exploding.gameObject != origin)
            {
                exploding.Explode();
            }
        }
        if(Vector3.Distance(FindObjectOfType<Stomach>().transform.position, transform.position) < 1f)
        {
            FindObjectOfType<PlayerController>().RemoveHealth(1,1);
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
