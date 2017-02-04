using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
    public GameObject[] Spawners;
    public float globalSpawnTime;
    public float ACoef, BCoef, CCoef;
    public float minSpawnTime;
    public GameObject[] spawnables;
    public float[] spawnRates;
    float timeSinceLastSpawn = 0;
    float time;
    int n = 0;
	// Use this for initialization
	void Start () {
        float mag = 0;
        //normalize the waited averages for easy RNG code
        for(int i = 0; i < spawnRates.Length; i++)
        {
            mag += spawnRates[i];
        }
        if (mag == 0)
            mag = 1;
        for (int i = 0; i < spawnRates.Length; i++)
        {
            spawnRates[i] /= mag;
        }
    }
	void spawnUnit(int index, GameObject spawnPoint, GameObject toGoTo)
    {
        GameObject unit = Instantiate(this.spawnables[index]);
        unit.transform.position = spawnPoint.transform.position;
    }
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= globalSpawnTime)
        {
            timeSinceLastSpawn = 0;
            //spawn our unit
            float v = Random.value;
            for(int i = 0; i < spawnRates.Length; i++)
            {
                v -= spawnRates[i];
                if(v <= 0)
                {
                    print("[" + n + "] option " + i);
                    //we have our unit to spawn, now we need to decide what spawn location, and where it should eventually path to
                    spawnUnit(i, Spawners[(int)(Random.value * Spawners.Length)], Spawners[(int)(Random.value * Spawners.Length)]);
                    i = spawnRates.Length;
                }
            }
            n++;
        }
        //modulate spawn rate by a quadratic equation entered in the inspector
        globalSpawnTime = ACoef * time * time + BCoef * time + CCoef;
        if (globalSpawnTime <= minSpawnTime)
            globalSpawnTime = minSpawnTime;
	}
}
