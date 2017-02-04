using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnStart : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        MeshRenderer mr = this.GetComponent<MeshRenderer>();
        mr.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
