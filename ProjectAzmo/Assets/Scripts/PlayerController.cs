using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private SteamVR_TrackedObject rTrackedObj;
    private SteamVR_Controller.Device rController { get { return SteamVR_Controller.Input((int)rTrackedObj.index); } }

    private SteamVR_TrackedObject lTrackedObj;
    private SteamVR_Controller.Device lController { get { return SteamVR_Controller.Input((int)lTrackedObj.index); } }

    public GameObject headCamera;
    public GameObject rightController;
    public GameObject leftController;

    private List<GameObject> triggeredObjects;

    void Start()
    {
        rTrackedObj = rightController.GetComponent<SteamVR_TrackedObject>();
        lTrackedObj = leftController.GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        if(rController.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {

        }
    }

    void OnTriggerEnter(Collision col)
    {
        if(col.gameObject.GetComponent<Interactable>())
        {
            triggeredObjects.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collision col)
    {
        triggeredObjects.Remove(col.gameObject);
    }
}
