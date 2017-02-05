using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    private int calories = 0;
    public int GetCalories() { return calories; }
    public void AddCalories(int num) { calories += num; HealthRegenCounter += num; if (HealthRegenCounter > 5) { AddHealth(1); } UpdateGUI(); }
    public void RemoveCalories(int num) { calories -= num; UpdateGUI(); }
    private int health = 5;
    public int GetHealth() { return health; }
    public void AddHealth(int num) { health += num; if (health > 5) { health = 5; } UpdateGUI(); }
    public void RemoveHealth(int num) { health -= num; if (health <= 0) { GameOver(); } UpdateGUI(); }

    private int HealthRegenCounter = 0;

    private Text healthText;
    private Text caloriesText;

    void Start()
    {
        rTrackedObj = rightController.GetComponent<SteamVR_TrackedObject>();
        lTrackedObj = leftController.GetComponent<SteamVR_TrackedObject>();

        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        caloriesText = GameObject.Find("CaloriesText").GetComponent<Text>();
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
        else
        {
            curController.transform.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
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
        curController.transform.GetChild(0).GetComponent<SphereCollider>().isTrigger = true;
        if (curController.transform.GetChild(0).GetComponent<ControllerScript>().heldObj != null)
        {
            curController.transform.GetChild(0).GetComponent<ControllerScript>().heldObj.GetComponent<Interactable>().ReleaseTrigger();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateGUI()
    {
        healthText.text = "Health: " + GetHealth();
        caloriesText.text = "Calories: " + GetCalories();
    }
}
