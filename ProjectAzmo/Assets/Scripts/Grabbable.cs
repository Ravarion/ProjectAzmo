using UnityEngine;
using System.Collections;

public class Grabbable : Interactable {

    public bool grabbed = false;
    public bool rightHand = false;

    public Vector3 oldPos;

    void Update()
    {
        if (grabbed)
        {
            oldPos = transform.position;
            transform.position = rightHand ? GameObject.Find("Controller (right)").transform.position : GameObject.Find("Controller (left)").transform.position;
        }
    }

    override public bool InteractTrigger(bool rightController)
    {
        rightHand = rightController;
        grabbed = true;
        return true;
    }

    override public bool ReleaseTrigger()
    {
        grabbed = false;
        rightHand = false;
        Vector3 velocity = transform.position - oldPos;
        GetComponent<Rigidbody>().velocity = velocity * 100;
        print(velocity);
        return true;
    }
}
