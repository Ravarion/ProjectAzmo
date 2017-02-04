using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public Material redFlashMat;
    public Material originalMat;
    public GameObject cannonBallPrefab;
    public float shootRate;
    private float shootTimer;

    private void Start()
    {
        shootTimer = shootRate + Random.Range(0f, 16f);
        gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
    }

    void Update () {
        shootTimer -= Time.deltaTime;
        if(shootTimer <= 0)
        {
            StartCoroutine("FlashRed");
            shootTimer = shootRate + Random.Range(0f, 16f);
        }
	}

    IEnumerator FlashRed()
    {
        for(float timer = 1f; timer >= 0; timer -= 0.05f)
        {
            if (Mathf.Approximately(timer,1) || Mathf.Approximately(timer, .75f) || Mathf.Approximately(timer, .5f) || Mathf.Approximately(timer, .25f))
            {
                if (gameObject.GetComponent<MeshRenderer>().material.color == Color.grey)
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                else
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
                }
                
            }
            yield return new WaitForSeconds(.05f);
        }
        Shoot();
    }

    void Shoot()
    {
        Quaternion originalRot = transform.rotation;
        transform.LookAt(FindObjectOfType<Stomach>().transform);
        GameObject cannonBall = Instantiate(cannonBallPrefab, transform.position + transform.forward*.1f, transform.rotation) as GameObject;
        Vector3 direction = cannonBall.transform.forward + cannonBall.transform.up * 0.9f;
        cannonBall.GetComponent<Rigidbody>().AddForce(direction*4.2f, ForceMode.Impulse);
        transform.rotation = originalRot;
    }
}
