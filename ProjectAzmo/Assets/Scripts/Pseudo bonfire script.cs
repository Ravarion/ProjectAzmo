using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AIMovement : MonoBehaviour {
	public float timer = 10f;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else if (timer <= 0)
        {
            timer = 10f;
            //light a bonfire
            //if(number of lit bonfires == 6
            //  {
            //  Game over
            //  }
        }
       
	}
    
}
