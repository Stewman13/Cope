using UnityEngine;
using System.Collections;

public class IsGrounded : MonoBehaviour {

	public GameObject Player;
	private BasicMovement _Mov;
	private CameraShake _shake;
	public bool landed = false;
	public bool shouldShake;

	// Use this for initialization
	void Start () {
		_Mov = Player.GetComponent<BasicMovement>();
		_shake = Camera.main.GetComponent<CameraShake>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerStay(Collider Col) {
		if (Col.gameObject.tag == "Ground" && !landed) {
			landed = true;
			_Mov.onGround = true;
			//Not shaking....
			if(_Mov.isAngry == true && shouldShake == true){
				_shake.shake = 0.05f;
				shouldShake = false;
			}
		} 
	}
	void OnTriggerExit(Collider Col){
		_Mov.onGround = false;
		landed = false;
	}
}
