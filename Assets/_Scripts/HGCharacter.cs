using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//记录人物数据
public class HGCharacter : MonoBehaviour {

    //人物状态----------
    public int Score=0;
	private HGBlockType GameMode=HGBlockType.Mode_Pause;
     //-------------------

    public void UpdateMode(HGBlockType mode) {
        GameMode = mode;
    }
    public HGBlockType GetMode() {
        return GameMode;
    }
}
