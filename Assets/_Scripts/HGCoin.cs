using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGCoin : MonoBehaviour {
	//数值配置----------
	[SerializeField] private float RotateSpeed;
	//--------------------

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.down * RotateSpeed, Space.World);
	}

	void OnTriggerEnter(Collider col) {
		transform.parent.gameObject.SetActive(false);
		GameObject.FindWithTag("Character_").GetComponent<HGCharacter>().UpdateScore();
	}
}
