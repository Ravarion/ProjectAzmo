using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public AudioClip cannonShotSound;
    public AudioClip fuseSound;

    public GameObject flashObj;
    public Material redFlashMat;
    public Material originalMat;
    public GameObject cannonBallPrefab;
    public float shootRate;
    private float shootTimer;

    private void Start()
    {
        shootTimer = shootRate + Random.Range(0f, 16f);
    }

    void Update() {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            StartCoroutine("FlashRed");
            shootTimer = shootRate + Random.Range(0f, 16f);
        }
    }

    IEnumerator FlashRed()
    {
        GetComponent<AudioSource>().clip = fuseSound;
        GetComponent<AudioSource>().Play();
        for (float timer = 1f; timer >= 0; timer -= 0.05f)
        {
            if (Mathf.Approximately(timer, 1) || Mathf.Approximately(timer, .75f) || Mathf.Approximately(timer, .5f) || Mathf.Approximately(timer, .25f))
            {
                if (flashObj.GetComponent<MeshRenderer>().material.color == Color.white)
                {
                    flashObj.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                else
                {
                    flashObj.GetComponent<MeshRenderer>().material.color = Color.white;
                }

            }
            yield return new WaitForSeconds(.05f);
        }
        Shoot();
    }

    public void Destruct()
    {
        transform.parent.GetComponent<TowerScript>().SetDead();
    }

    void Shoot()
    {
        GetComponent<AudioSource>().clip = cannonShotSound;
        GetComponent<AudioSource>().Play();
        Quaternion originalRot = transform.rotation;
        transform.LookAt(FindObjectOfType<Stomach>().transform);
        GameObject cannonBall = Instantiate(cannonBallPrefab, transform.position + transform.forward*.1f, transform.rotation) as GameObject;
        Vector3 direction = cannonBall.transform.forward + cannonBall.transform.up * 0.9f;
        cannonBall.GetComponent<Rigidbody>().AddForce(direction*4.2f, ForceMode.Impulse);
        transform.rotation = originalRot;
    }
}
