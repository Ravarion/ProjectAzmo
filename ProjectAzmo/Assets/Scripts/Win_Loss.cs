using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Loss : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Win()
    {

    }

    public void Lose(int whyDidYouDie)
    {
        string endText = "";
        if(whyDidYouDie == 0)           //Death by Exploding Human
        {
            endText = "You have been slain by a soldier";
        }
        else if(whyDidYouDie == 1)      //Death by Cannonball
        {
            endText = "You have been slain from afar";
        }
        else if(whyDidYouDie == 2)      //Death by Bonfire
        {
            endText = "The beacon's were lit, and you were outnumbered";
        }

        SceneManager.LoadScene(1); //fade into game over screen/scene
        //enable option to go back to main menu (throw a human at the option?)
    }
}
