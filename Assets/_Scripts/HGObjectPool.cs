using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGObjectPool : MonoBehaviour {
	private List<GameObject> pool = new List<GameObject>();

	private HGObjectPool() { }
	private static HGObjectPool ins;

	public static HGObjectPool GetIns() {
		if (ins == null)
			ins = new GameObject("HGObjectPool").AddComponent<HGObjectPool>();
		return ins;
	}

	public GameObject Enpool(GameObject target) {
		GameObject res;
		res = pool.Find(tar => tar.name.Equals(target.name+"(Clone)"));
		if (res == null) {
			print("unmatched");
			res = Instantiate(target);
		} else {
			print("matched");
			res.SetActive(true);
			pool.Remove(res);
		}
		return res;
	}

	public void Depool(GameObject target) {
		target.SetActive(false);
		pool.Add(target);
	}
}
