using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AIMovement : MonoBehaviour {
	public Vector3 destination;
	Vector3[] spawnPoints;
	public float timer;
	public int timeToExit;
    public int finalDestination;

	// Use this for initialization
	void Start () {
		timer = Random.Range (1f, 4f);
		timeToExit = Random.Range (3, 5);
        if (tag == "explosive")
            destination = FindObjectOfType<Stomach>().transform.position;
        else
		    destination = RandCoord();
		GetComponent<NavMeshAgent> ().SetDestination (destination);
        GameObject[] spawnScripts = GameObject.FindGameObjectsWithTag("Spawner");
		spawnPoints = new Vector3[spawnScripts.Length];
		for (int i = 0; i < spawnScripts.Length; i++) {
			spawnPoints [i] = spawnScripts[i].transform.position;
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (tag != "explosive")
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else if (timer <= 0)
            {
                if(timeToExit > 0)
                    timeToExit -= 1;
                if (timeToExit == 0)
                {
                    timeToExit -= 1;
                    finalDestination = Random.Range(0, spawnPoints.Length);
                    GetComponent<NavMeshAgent>().SetDestination(spawnPoints[finalDestination]);
                }
                else if(timeToExit > 0)
                {
                    timer = Random.Range(1, 4);
                    destination = RandCoord();
                    GetComponent<NavMeshAgent>().SetDestination(destination);
                }
            }
            if (timeToExit < 0)
            {
                if (Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination) <= 0.1)
                    Destroy(gameObject);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination) <= 0.5)
                Destroy(gameObject);
        }
	}

	Vector3 RandCoord()
	{
		float xCoord = Random.Range (-0.8f, 0.8f);
		float yCoord = 0.9f;
		float zCoord = Random.Range (0f, 1.25f);
        Vector3 coord = new Vector3(xCoord, yCoord, zCoord);
        while (coord.x >= -0.65f && coord.x <= 0.65f && coord.z >= 0f && coord.z <= 0.65f)
            coord = RandCoord();
        return coord;
	}
}
