using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AIMovement : MonoBehaviour {
	public Vector3 destination;
	GameObject[] spawnPoints;
	public float timer;
	public int timeToExit;
    public int finalDestination;

	// Use this for initialization
	void Start () {
		timer = Random.Range (1f, 4f);
		timeToExit = Random.Range (3, 5);
        if (tag == "explosive")
        {
            destination = FindObjectOfType<Stomach>().transform.position;
            destination = new Vector3(destination.x, 0.9f, destination.z);
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
        else
        {
            spawnPoints = GameObject.FindGameObjectsWithTag("spawner");
            destination = spawnPoints[0].transform.position;
            destination = new Vector3(destination.x, 0.9f, destination.z);
            destination = RandCoord();
            GetComponent<NavMeshAgent> ().SetDestination (destination);
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
                    destination = spawnPoints[finalDestination].transform.position;
                    GetComponent<NavMeshAgent>().SetDestination(destination);
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
                if (Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination) <= 0.01)
                    Destroy(gameObject);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination) <= 0.5)
            {
                GetComponent<Exploding>().Explode();
            }
        }
	}

	Vector3 RandCoord()
	{
		float xCoord = Random.Range (-0.8f, 0.8f);
		float yCoord = 0.0f;
		float zCoord = Random.Range (0f, 1.25f);
        Vector3 coord = new Vector3(xCoord, yCoord, zCoord);
        while (coord.x >= -0.65f && coord.x <= 0.65f && coord.z >= 0f && coord.z <= 0.65f)
            coord = RandCoord();
        return coord;
	}
}
