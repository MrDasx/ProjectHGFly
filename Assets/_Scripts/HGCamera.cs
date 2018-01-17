using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGCamera :  MonoBehaviour {
    GameObject CharacterEntity;
    //数值配置----------
    public float CameraHeight = 3f;
    public float CameraDistance = -10f;
    //--------------------

	// Use this for initialization
	void Start () {
        CharacterEntity = GameObject.Find("Character");
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position = new Vector3(CharacterEntity.transform.position.x, CameraHeight, CameraDistance);
    }
}
