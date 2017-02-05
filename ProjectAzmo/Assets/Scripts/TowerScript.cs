using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {

    public Mesh destroyedModel;
    public GameObject cannon;
    public bool towerDestroyed = false;
    private bool dead;
    private float deadTimer;
    public float respawnLatency;

	void Update () {
        if(towerDestroyed)
        {
            return;
        }
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

    public void DestroyTower()
    {
        towerDestroyed = true;
        //transform.FindChild("default").GetComponent<MeshFilter>().mesh = destroyedModel;
        //transform.FindChild("Cannon(Clone)").gameObject.SetActive(false);
        FindObjectOfType<PlayerController>().destroyedTowers++;
        if(FindObjectOfType<PlayerController>().destroyedTowers >= 2)
        {
            FindObjectOfType<PlayerController>().Win();
        }
        Destroy(gameObject);
    }

    public void SetDead()
    {
        dead = true;
        deadTimer = respawnLatency;
        cannon.SetActive(false);
    }
}
