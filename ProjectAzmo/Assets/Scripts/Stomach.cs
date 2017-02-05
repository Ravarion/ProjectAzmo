using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomach : Interactable {

    public GameObject pukeBallFab;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "human")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerController>().AddCalories(1); //Note: In text it should show this being x100,000
        }
        /*if(collision.gameObject.tag == "poison")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerController>().RemoveHealth(1);
        }*/
    }

    public override bool InteractTrigger(bool rightController, GameObject curController)
    {
        if(FindObjectOfType<PlayerController>().GetCalories() >= 3)
        {
            GetComponent<AudioSource>().Play();
            GameObject pukeBall = Instantiate(pukeBallFab) as GameObject;
            pukeBall.GetComponent<Grabbable>().InteractTrigger(rightController, curController);
            curController.transform.GetChild(0).GetComponent<ControllerScript>().heldObj = pukeBall;
            FindObjectOfType<PlayerController>().RemoveCalories(3);
            return true;
        }
        else
        {
            return false;
        }
    }
}
