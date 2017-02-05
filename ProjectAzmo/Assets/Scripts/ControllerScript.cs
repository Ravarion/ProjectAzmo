using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

    public GameObject collidedObj;
    public GameObject heldObj;

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        if(other.GetComponent<Interactable>())
        {
            collidedObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Interactable>())
        {
            if (other.gameObject == collidedObj)
            {
                collidedObj = null;
            }
        }
    }
}
