using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    virtual public bool InteractTrigger()
    {
        return false;
    }

    virtual public bool InteractCollision()
    {
        return false;
    }
}
