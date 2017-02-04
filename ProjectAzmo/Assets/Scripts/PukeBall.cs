using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeBall : Grabbable {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Tower")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.gameObject.GetComponent<Cannon>())
        {
            Destroy(collision.gameObject);
        }
    }
}
