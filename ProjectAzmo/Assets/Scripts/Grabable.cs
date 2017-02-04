using UnityEngine;
using System.Collections;

public class Grabable : Interactable {

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
}
