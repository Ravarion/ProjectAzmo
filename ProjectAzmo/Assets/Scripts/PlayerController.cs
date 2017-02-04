using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private SteamVR_TrackedObject rTrackedObj;
    public SteamVR_Controller.Device rController { get { return SteamVR_Controller.Input((int)rTrackedObj.index); } }

    private SteamVR_TrackedObject lTrackedObj;
    public SteamVR_Controller.Device lController { get { return SteamVR_Controller.Input((int)lTrackedObj.index); } }

    public GameObject headCamera;
    public GameObject rightController;
    public GameObject leftController;

    public int calories;
    public int health;

    void Start()
    {
        rTrackedObj = rightController.GetComponent<SteamVR_TrackedObject>();
        lTrackedObj = leftController.GetComponent<SteamVR_TrackedObject>();

        calories = 0;
        health = 3;
    }

    void Update()
    {
        if(rController.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            InteractTrigger(true);
        }
        if (rController.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            ReleaseTrigger(true);
        }
        if (lController.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            InteractTrigger(false);
        }
        if (lController.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            ReleaseTrigger(false);
        }
    }

    private void InteractTrigger(bool rightHand)
    {
        /*Interactable[] interactableObjects = FindObjectsOfType<Interactable>();
        float shortestDistance = 1000;
        GameObject closestObject = null;
        foreach (Interactable curObj in interactableObjects)
        {
            float objDist = Vector3.Distance(rightController.transform.position, curObj.transform.position);
            if (objDist < shortestDistance)
            {
                shortestDistance = objDist;
                closestObject = curObj.gameObject;
            }
        }*/
        GameObject curController = rightHand ? rightController : leftController;
        ControllerScript curContScript = curController.transform.GetChild(0).GetComponent<ControllerScript>();
        if (curContScript.collidedObj != null)
        {
            curContScript.collidedObj.GetComponent<Interactable>().InteractTrigger(rightHand, curController);
            if(curContScript.collidedObj.GetComponent<Grabbable>())
            {
                curContScript.heldObj = curContScript.collidedObj;
            }
        }
    }

    private void ReleaseTrigger(bool rightHand)
    {
        /*Interactable[] interactableObjects = FindObjectsOfType<Grabbable>();
        foreach (Interactable curObj in interactableObjects)
        {
            if (curObj.GetComponent<Grabbable>().grabbed && curObj.GetComponent<Grabbable>().rightHand == rightHand)
            {
                curObj.GetComponent<Grabbable>().ReleaseTrigger();
            }
        }*/
        GameObject curController = rightHand ? rightController : leftController;
        if (curController.transform.GetChild(0).GetComponent<ControllerScript>().heldObj != null)
        {
            curController.transform.GetChild(0).GetComponent<ControllerScript>().heldObj.GetComponent<Interactable>().ReleaseTrigger();
        }
    }
}
