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
			print("unmatched\n");
			res = Instantiate(target);
		} else {
			print("matched\n");
			pool.Remove(res);
		}
		res.SetActive(true);
		return res;
	}

	public void Depool(GameObject target) {
		target.SetActive(false);
		pool.Add(target);
	}
}
