using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGEnvironment : MonoBehaviour {
    Queue<GameObject> Blocks;
    int posX = 0;
	// Use this for initialization
	void Start () {
		
	}
	
    void Awake() {

    }
	// Update is called once per frame
	void Update () {
		
	}
    public void Environ_Init() {
        GameObject objTemp = Instantiate(HGBlock.getBlock(HGBlockType.Mode_Flypee));
        objTemp
    }
    public void Environ_Update() {

    }
}

public class HGBlock {
    public static GameObject getBlock(HGBlockType Type) {
        if (Type == HGBlockType.Mode_Flypee) {
            return (GameObject)Resources.Load("_Prefabs/Flypee_Prefab");
        } else
            return null;
    }
}

public enum HGBlockType {
    Mode_Flypee;
}
