using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGCharacter : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(3f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        print("got it");
    }
}
