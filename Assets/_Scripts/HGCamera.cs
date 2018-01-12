using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGCamera :  MonoBehaviour {
    GameObject CharacterEntity;
    const float CameraHeight = 3f;
    const float CameraDistance = -10f;
	// Use this for initialization
	void Start () {
        CharacterEntity = GameObject.Find("Character");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        this.gameObject.GetComponent<Transform>().position = new Vector3(CharacterEntity.transform.position.x, CameraHeight, CameraDistance);
    }
}
