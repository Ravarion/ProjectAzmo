using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeBall : Grabbable {

    public GameObject explosionFab;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "CannonTower")
        {
            Instantiate(explosionFab, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<TowerScript>().DestroyTower();
            Destroy(gameObject);
        }
        if(collision.gameObject.GetComponent<Cannon>())
        {
            Destroy(collision.gameObject);
        }
    }
}
