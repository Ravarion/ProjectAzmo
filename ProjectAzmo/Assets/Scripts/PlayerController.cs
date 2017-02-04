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

    void Start()
    {
        rTrackedObj = rightController.GetComponent<SteamVR_TrackedObject>();
        lTrackedObj = leftController.GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        if(rController.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Interactable[] interactableObjects = FindObjectsOfType<Interactable>();
            float shortestDistance = 1000;
            GameObject closestObject = null;
            foreach(Interactable curObj in interactableObjects)
            {
                float objDist = Vector3.Distance(rightController.transform.position, curObj.transform.position);
                if (objDist < shortestDistance)
                {
                    shortestDistance = objDist;
                    closestObject = curObj.gameObject;
                }
            }
            if(closestObject != null)
            {
                closestObject.GetComponent<Interactable>().InteractTrigger(true);
            }
            else
            {
                
            }
        }
        if (rController.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Interactable[] interactableObjects = FindObjectsOfType<Grabbable>();
            foreach (Interactable curObj in interactableObjects)
            {
                if (curObj.GetComponent<Grabbable>().grabbed && curObj.GetComponent<Grabbable>().rightHand)
                {
                    curObj.GetComponent<Grabbable>().ReleaseTrigger();
                }
            }
        }
    }
}
