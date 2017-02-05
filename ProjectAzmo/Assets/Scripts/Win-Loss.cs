using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Loss : MonoBehaviour {

   private string endText = "";

    // Use this for initialization
    void Start () {
        GameObject.DontDestroyOnLoad(gameObject);
	}

    void Win(int soldiersKilled)
    {
        endText = "After you murdered " + soldiersKilled + " soldiers, you ravaged the kingdom and left their civilization in ruins. You monster.";
        SceneManager.LoadScene(1); //fade into game over screen/scene
    }

    void Lose(int soldiersKilled, int whyDidYouDie)
    {
        if(whyDidYouDie == 0)           //Death by Exploding Human
        {
            endText = "After you murdered " + soldiersKilled + " soldiers, you were slain by a soldier";
        }
        else if(whyDidYouDie == 1)      //Death by Cannonball
        {
            endText = "After you murdered " + soldiersKilled + " soldiers, you were slain from afar";
        }
        else if(whyDidYouDie == 2)      //Death by Bonfire
        {
            endText = "After you murdered " + soldiersKilled + " soldiers, the beacon's were lit, and you were outnumbered";
        }

        SceneManager.LoadScene(1); //fade into game over screen/scene
        //enable option to go back to main menu (throw a human at the option?)
    }
}
