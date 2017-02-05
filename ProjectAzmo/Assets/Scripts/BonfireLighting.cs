using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class BonfireLighting : MonoBehaviour {
	public float timer = 10f;
    private float curTimer;

    public GameObject[] bonfires;
    private int curBonfire = 0;

    private void Start()
    {
        curTimer = timer;
    }

    void Update()
    {
        print(curTimer);
        if (curTimer > 0)
            curTimer -= Time.deltaTime;
        else if (curTimer <= 0)
        {
            curTimer = timer;
            bonfires[curBonfire].SetActive(true);
            curBonfire++;
            if(curBonfire >= bonfires.Length)
            {
                //Lose
            }
        }
       
	}
    
}
