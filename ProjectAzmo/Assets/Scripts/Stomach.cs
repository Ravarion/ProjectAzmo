using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomach : Interactable {

    public GameObject pukeBallFab;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Human")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerController>().calories += 1; //Note: In text it should show this being x100,000
        }
    }

    public override bool InteractTrigger(bool rightController, GameObject curController)
    {
        GameObject pukeBall = Instantiate(pukeBallFab) as GameObject;
        pukeBall.GetComponent<Grabbable>().InteractTrigger(rightController, curController);
        curController.transform.GetChild(0).GetComponent<ControllerScript>().heldObj = pukeBall;
        return true;
    }
}
