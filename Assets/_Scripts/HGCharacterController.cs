using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制人物移动
public class HGCharacterController : MonoBehaviour {
	//数值配置----------
	[SerializeField] private float MoveSpeed;
	[SerializeField] private float SpeedLimit;
	[SerializeField] private float JumpForce;
	[SerializeField] private float Gravity;
	[SerializeField] private float StartHeight;
	[SerializeField] private HGBlockType STARTMODE = HGBlockType.Mode_Flypee;
    //--------------------

    HGCharacter Charc;
	GameObject Environ;
    // Use this for initialization
    void Start () {
        Charc = this.gameObject.GetComponent<HGCharacter>();
		Environ = GameObject.FindWithTag("Environment_");
		Charc.transform.position = new Vector3(0f, StartHeight, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        switch (Charc.GetMode()) {
            case HGBlockType.Mode_Pause:
                GetComponent<ConstantForce>().force = new Vector3(0f, 0f, 0f);
				GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
				if (Input.GetKeyDown(KeyCode.Space)) {
					print("Started\n");
                    Charc.UpdateMode(HGBlockType.Mode_Start);
                }
                break;
            case HGBlockType.Mode_Flypee:
                if (Input.GetKeyDown(KeyCode.Space)) {
                    Vector3 VecTemp = new Vector3(0f, (GetComponent<Rigidbody>().velocity.y < SpeedLimit ? JumpForce : 0f), 0f);
                    GetComponent<Rigidbody>().AddForce(VecTemp);
                }
				if (Input.GetKey(KeyCode.A)) {
					print("Paused\n");
					Charc.UpdateMode(HGBlockType.Mode_Pause);
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
					print("Reseted\n");
                    GetComponent<Transform>().position = new Vector3(0f, StartHeight, 0f);
                    GetComponent<ConstantForce>().force = new Vector3(0f, 0f, 0f);
                    GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
					Environ.GetComponent<HGEnvironment>().Environ_Init();
                    Charc.UpdateMode(HGBlockType.Mode_Pause);
                }
                break;
            default:
                break;
        }
	}//待完善

    void OnCollisionEnter(Collision collision) {
        Charc.UpdateMode(HGBlockType.Mode_End);
    }
}
