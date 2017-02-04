using UnityEngine;
using System.Collections;

public class GrabParent : MonoBehaviour {

    public bool grabbed = false;
    public bool rightHand = false;

    public Vector3 oldPos;

    void Update()
    {
        if (grabbed)
        {
            oldPos = transform.position;
            transform.position = rightHand ? GameObject.Find("Controller (right)").transform.position : GameObject.Find("Controller (right)").transform.position;
        }
    }
}
