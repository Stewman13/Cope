using UnityEngine;
using System.Collections;

public class IsWalledRight : MonoBehaviour {

	public GameObject Player;
	private BasicMovement _Mov;
	private CameraShake _shake;
	
	// Use this for initialization
	void Start () {
		_Mov = Player.GetComponent<BasicMovement>();
		_shake = Camera.main.GetComponent<CameraShake>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider Col) {
		if (Col.gameObject.tag == "Wall") {
			_Mov.onRightWall = true;
		} 
	}
	void OnTriggerExit(Collider Col){
		_Mov.onRightWall = false;
	}
}
