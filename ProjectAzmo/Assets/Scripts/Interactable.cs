using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    virtual public bool InteractTrigger(bool rightController)
    {
        return false;
    }

    virtual public bool InteractCollision()
    {
        return false;
    }

    virtual public bool ReleaseTrigger()
    {
        return false;
    }
}
