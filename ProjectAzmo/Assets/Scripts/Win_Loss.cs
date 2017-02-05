using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Loss : MonoBehaviour {

    string endText = "";
    float timer = 4;
    bool fadeOut = false;
    bool fadeIn = false;
    string[] credits;
    int currentCredit = 0;

    // Use this for initialization
    void Start () {
        GameObject.DontDestroyOnLoad(gameObject);
        credits = new string[9];
        credits[1] = "Lead Developer: Steven Lindbloom";
        credits[2] = "Programmer: Erich Giesfeldt";
        credits[3] = "Programmer: Scott Thom";
        credits[4] = "Music Producer: Christina Miller";
        credits[5] = "3D Artist: Morgan Brantner";
        credits[6] = "2D Artist: Marjory Quail";
        credits[7] = "Off=site Artist: Daniel Bodunov";
        credits[8] = "Thank you for playing!";
    }
	
	// Update is called once per frame
	void Update () {
        credits[0] = endText;
		if(SceneManager.GetActiveScene().name == "")
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                if(!fadeOut && !fadeIn)
                {
                    timer = 1;
                    fadeOut = true;
                }
                else if(fadeOut && !fadeIn)
                {
                    timer = 1;
                    fadeOut = false;
                    fadeIn = true;
                    currentCredit++;
                }
                else if(!fadeOut && fadeIn)
                {
                    timer = 2;
                    fadeIn = false;
                }
            }
        }
	}

    public void Win(int soldiersKilled)
    {
        endText = "After killing " + soldiersKilled + " soldiers, you ravaged the kingdom and left their civilization in ruins.";
        SceneManager.LoadScene(1); //fade into game over screen/scene
    }

    public void Lose(int soldiersKilled, int whyDidYouDie)
    {
        if(whyDidYouDie == 0)           //Death by Exploding Human
        {
            endText = "After killing " + soldiersKilled + " soldiers, you were slain by a soldier.";
        }
        else if(whyDidYouDie == 1)      //Death by Cannonball
        {
            endText = "After killing " + soldiersKilled + " soldiers, you were slain from afar.";
        }
        else if(whyDidYouDie == 2)      //Death by Bonfire
        {
            endText = "After killing " + soldiersKilled + " soldiers, the beacon's were lit, and you were outnumbered.";
        }

        SceneManager.LoadScene(1); //fade into game over screen/scene
        //enable option to go back to main menu (throw a human at the option?)
    }
}
