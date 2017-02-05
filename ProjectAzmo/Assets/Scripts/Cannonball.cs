using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Grabbable {

    private bool active = true;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Stomach>())
        {
            if(active)
            {
                FindObjectOfType<PlayerController>().RemoveHealth(1, 0);
            }
            else
            {
                FindObjectOfType<PlayerController>().AddCalories(1);
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.name == "Model")
        {
            active = false;
        }
    }

    public override bool InteractTrigger(bool rightController, GameObject curController)
    {
        active = false;
        return base.InteractTrigger(rightController, curController);
    }
}
