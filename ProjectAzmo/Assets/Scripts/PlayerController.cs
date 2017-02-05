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

    public AudioClip hurtSound;
    public AudioClip dieSound;
    public AudioClip biteSound;

    private int calories = 0;
    public int GetCalories() { return calories; }
    public void AddCalories(int num) { PlayBiteSound(); calories += num; AddRegenCounter(num); UpdateGUI(); }
    public void RemoveCalories(int num) { calories -= num; UpdateGUI(); }
    public int health = 5;
    public int GetHealth() { return health; }
    public void AddHealth(int num) { health += num; if (health > 5) { health = 5; } UpdateGUI(); }
    public void RemoveHealth(int num, int damageType) { health -= num; if (health <= 0) { Lose(damageType); return; } UpdateGUI(); PlayHurtSound(); }

    private int healthRegenCounter = 0;
    public void AddRegenCounter(int num) { healthRegenCounter += num; if (healthRegenCounter >= 3) { healthRegenCounter = 0; AddHealth(1); } }

    private Text healthText;
    private Text caloriesText;

    public int destroyedTowers = 0;
    public int murderedSoldiers = 0;

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
            if(rightController.transform.FindChild("Model").GetComponent<Animator>())
            {
                rightController.transform.FindChild("Model").GetComponent<Animator>().SetBool("Closed", true);
            }
            InteractTrigger(true);
        }
        if (rController.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (rightController.transform.FindChild("Model").GetComponent<Animator>())
            {
                rightController.transform.FindChild("Model").GetComponent<Animator>().SetBool("Closed", false);
            }
            ReleaseTrigger(true);
        }
        if (lController.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (leftController.transform.FindChild("Model").GetComponent<Animator>())
            {
                leftController.transform.FindChild("Model").GetComponent<Animator>().SetBool("Closed", true);
            }
            InteractTrigger(false);
        }
        if (lController.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (leftController.transform.FindChild("Model").GetComponent<Animator>())
            {
                leftController.transform.FindChild("Model").GetComponent<Animator>().SetBool("Closed", false);
            }
            ReleaseTrigger(false);
        }
    }

    public void Win()
    {

    }

    public void Lose(int loseMethod)
    {
        PlayDieSound();
        //StartCoroutine("FadeToBlack");
    }

    private IEnumerator FadeToBlack()
    {
        yield return new WaitForSeconds(3f);
        //TODO: Find<WinLose>().Lose()
    }

    private void PlayHurtSound()
    {
        GetComponent<AudioSource>().clip = hurtSound;
        GetComponent<AudioSource>().Play();
    }

    private void PlayDieSound()
    {
        GetComponent<AudioSource>().clip = dieSound;
        GetComponent<AudioSource>().Play();
    }

    private void PlayBiteSound()
    {
        GetComponent<AudioSource>().clip = biteSound;
        GetComponent<AudioSource>().Play();
    }

    private void InteractTrigger(bool rightHand)
    {
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
        GameObject curController = rightHand ? rightController : leftController;
        curController.transform.GetChild(0).GetComponent<SphereCollider>().isTrigger = true;
        if (curController.transform.GetChild(0).GetComponent<ControllerScript>().heldObj != null)
        {
            curController.transform.GetChild(0).GetComponent<ControllerScript>().heldObj.GetComponent<Interactable>().ReleaseTrigger();
        }
    }

    private void UpdateGUI()
    {
        healthText.text = "Health: " + GetHealth();
        caloriesText.text = "Iron: " + GetCalories();
    }
}
