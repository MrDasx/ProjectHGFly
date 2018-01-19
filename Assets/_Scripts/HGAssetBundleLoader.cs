using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGAssetBundleLoader : MonoBehaviour {
    private HGAssetBundleLoader() { }

    private static HGAssetBundleLoader ins;
	private static AssetBundle bundle;
	private static string FileName="prefabs";
	private static string BundleURL =
#if UNITY_ANDROID
                    "jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_IPHONE
                    Application.dataPath + "/Raw/";  
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
                    "file://" + Application.dataPath + "/_AssetBundles/";
#else
                    string.Empty;  
#endif

public static HGAssetBundleLoader GetIns() {
		if (ins == null)
			ins = new GameObject("HGAssetBundleLoader").AddComponent<HGAssetBundleLoader>();
		return ins;
    }

	public AssetBundle GetBundle() {
		if (bundle == null) {
			WWW loader = new WWW(BundleURL + FileName);
			bundle = loader.assetBundle;
		}
		return bundle;
	}
}
