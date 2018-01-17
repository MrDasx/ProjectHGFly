using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制人物移动
public class HGCharacterController : MonoBehaviour {
    //数值配置----------
    private float MoveSpeed = 7f;
    private float SpeedLimit = 10f;
    private float JumpForce = 900f;
    private float Gravity = -30f;
    private float StartHeight = 6f;
    private HGBlockType STARTMODE = HGBlockType.Mode_Flypee;
    //--------------------

    HGCharacter Charc;
    // Use this for initialization
    void Start () {
        Charc = this.gameObject.GetComponent<HGCharacter>();
        Charc.transform.position = new Vector3(0f, StartHeight, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        switch (Charc.GetMode()) {
            case HGBlockType.Mode_Pause:
                GetComponent<ConstantForce>().force = new Vector3(0f, 0f, 0f);
                if (Input.GetKeyDown(KeyCode.Space)) {
                    Charc.UpdateMode(HGBlockType.Mode_Start);
                }
                break;
            case HGBlockType.Mode_Flypee:
                if (Input.GetKeyDown(KeyCode.Space)) {
                    Vector3 VecTemp = new Vector3(0f, (GetComponent<Rigidbody>().velocity.y < SpeedLimit ? JumpForce : 0f), 0f);
                    GetComponent<Rigidbody>().AddForce(VecTemp);
                }
                break;
            case HGBlockType.Mode_Start:
                GetComponent<ConstantForce>().force = new Vector3(0f, Gravity, 0f);
                GetComponent<Rigidbody>().velocity = new Vector3(MoveSpeed, 0f);
                Charc.UpdateMode(HGBlockType.Mode_Flypee);
                break;
            case HGBlockType.Mode_End:
                GetComponent<Rigidbody>().velocity -= new Vector3(0f, GetComponent<Rigidbody>().velocity.x);
                if (Input.GetKeyDown(KeyCode.S)) {
                    GetComponent<Transform>().position = new Vector3(0f, StartHeight, 0f);
                    GetComponent<ConstantForce>().force = new Vector3(0f, 0f, 0f);
                    GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                    Charc.UpdateMode(HGBlockType.Mode_Pause);
                }
                break;
            default:
                break;
        }
	}

    void OnCollisionEnter(Collision collision) {
        Charc.UpdateMode(HGBlockType.Mode_End);
    }
}
