using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : Grabbable {

    public AudioClip yellingSound;
    public GameObject explosionFab;
    bool primed = false;

    public override bool ReleaseTrigger()
    {
        GetComponent<Animator>().SetBool("Exploding", true);
        primed = true;
        return base.ReleaseTrigger();
    }

    public override bool InteractTrigger(bool rightController, GameObject curController)
    {
        if(!GetComponent<Animator>().GetBool("Exploding"))
        {
            GetComponent<Animator>().SetBool("Caught", true);
        }
        GetComponent<AudioSource>().clip = yellingSound;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
        return base.InteractTrigger(rightController, curController);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(primed)
        {
            Explode();
        }
    }

    public IEnumerator StartExplodeAnimation()
    {
        GetComponent<Animator>().SetBool("Exploding", true);
        yield return new WaitForSeconds(2f);
        Explode();
    }

    public void Explode()
    {
        GameObject explosion = Instantiate(explosionFab, transform.position, transform.rotation);
        explosion.GetComponent<Explosion>().origin = gameObject;
        FindObjectOfType<PlayerController>().murderedSoldiers++;
        Destroy(gameObject);
    }
}
