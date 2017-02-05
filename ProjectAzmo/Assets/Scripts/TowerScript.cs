using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {

    public GameObject cannon;
    private bool dead;
    private float deadTimer;
    public float respawnLatency;

	void Update () {
        if (dead)
        {
            deadTimer -= Time.deltaTime;
            if(deadTimer <= 0)
            {
                cannon.SetActive(true);
                dead = false;
            }
        }
	}

    public void SetDead()
    {
        dead = true;
        deadTimer = respawnLatency;
        cannon.SetActive(false);
    }
}
