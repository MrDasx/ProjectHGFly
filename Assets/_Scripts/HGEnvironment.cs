using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGEnvironment : MonoBehaviour {
    //数值配置----------
    private float width = 30.0f;
    private float blank = 4f;
    //--------------------
	int posX = 0;
	private Queue<GameObject> objQueue = new Queue<GameObject>();
	GameObject CharacterEntity;
	// Use this for initialization
	void Start () {
		CharacterEntity = GameObject.Find("Character");
		Invoke("Environ_Init", 0f);
	}

	// Update is called once per frame
	void Update () {
		
	}
    public void Environ_Init() {
		posX = 0;
		while (objQueue.Count >0)
			HGObjectPool.GetIns().Depool(objQueue.Dequeue());
        GameObject objTemp = HGObjectPool.GetIns().Enpool(HGBlock.getBlock(HGBlockType.Mode_Start) as GameObject);
        objTemp.GetComponent<Transform>().position = new Vector3(posX++*width,0f,0f);
		objQueue.Enqueue(objTemp);
		GameObject objTemp2 = HGBlock.getBlock(HGBlockType.Mode_Flypee) as GameObject;
        while (posX <= 5) {
			GameObject objTemp1 = HGObjectPool.GetIns().Enpool(objTemp2);
            objTemp1.GetComponent<Transform>().position = new Vector3(posX++ * width, 0f, 0f);
			HGBlock.FlypeeSetup(ref objTemp1,blank);
			objQueue.Enqueue(objTemp1);
        }
    }
    public void Environ_Update() {
		if (objQueue.Peek().transform.position.x - CharacterEntity.transform.position.x < -width) {

		}
    }
	public void Environ_Reset() {
		posX = 0;
		Environ_Init();
	}
}

public class HGBlock {
	private static System.Random ra = new System.Random();
    public static Object getBlock(HGBlockType Type) {
        if (Type == HGBlockType.Mode_Flypee) {
            return HGAssetBundleLoader.GetIns().GetBundle().LoadAsset("Flypee_Prefab.prefab");
        } else if (Type == HGBlockType.Mode_Start) {
            return HGAssetBundleLoader.GetIns().GetBundle().LoadAsset("Start_Prefab.prefab");
        } else
            return null;
    }
	public static void FlypeeSetup(ref GameObject target,float blank){
		float t = (float)ra.Next(50, 150) / 100f * 3f;
		target.transform.Find("Ob1").GetComponent<Transform>().localScale = new Vector3(3f, t, 3f);
		target.transform.Find("Ob1 (1)").GetComponent<Transform>().localScale = new Vector3(3f, 10f - t - blank, 3f);
		t = (float)ra.Next(50, 150) / 100f * 3f;
		target.transform.Find("Ob2").GetComponent<Transform>().localScale = new Vector3(3f, t, 3f);
		target.transform.Find("Ob2 (1)").GetComponent<Transform>().localScale = new Vector3(3f, 10f - t - blank, 3f);
		t = (float)ra.Next(50, 150) / 100f * 3f;
		target.transform.Find("Ob3").GetComponent<Transform>().localScale = new Vector3(3f, t, 3f);
		target.transform.Find("Ob3 (1)").GetComponent<Transform>().localScale = new Vector3(3f, 10f - t - blank, 3f);
	}
}

public enum HGBlockType {
    Mode_Flypee,Mode_Start,Mode_Pause,Mode_End
}
