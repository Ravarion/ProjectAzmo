using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Grabbable : Interactable {

    public bool grabbed = false;
    public bool rightHand = false;

    void Update()
    {
        if (grabbed)
        {
            transform.position = rightHand ? GameObject.Find("Controller (right)").transform.position : GameObject.Find("Controller (left)").transform.position;
        }
    }

    override public bool InteractTrigger(bool rightController, GameObject curController)
    {
        rightHand = rightController;
        grabbed = true;
        if(GetComponent<AIMovement>())
        {
            GetComponent<AIMovement>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<AudioSource>().Stop();
        }
        return true;
    }

    override public bool ReleaseTrigger()
    {
        if (rightHand)
        {
            GetComponent<Rigidbody>().velocity = FindObjectOfType<PlayerController>().rController.velocity;
            GetComponent<Rigidbody>().angularVelocity = FindObjectOfType<PlayerController>().rController.angularVelocity;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = FindObjectOfType<PlayerController>().lController.velocity;
            GetComponent<Rigidbody>().angularVelocity = FindObjectOfType<PlayerController>().lController.angularVelocity;
        }
        grabbed = false;
        rightHand = false;
        
        return true;
    }
}
