using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {

	public GameObject Earthqauke;

	public GameObject Animator;
	public Animator anim;

	public Transform myTransform;

	public Transform CurrentCheckpoint;
	public Transform Checkpoint1;
	public Transform Checkpoint2;
	public Transform Checkpoint3;
	public Transform Checkpoint4;
	public Transform Checkpoint5;
	public Transform Checkpoint6;
	public Transform Checkpoint7;
	public Transform Checkpoint8;

	public bool ShouldMove = false;

	public GameObject me;
	
	public float speed;

	public bool isWaiting = false;
	public bool StopWaiting = false;
	// Use this for initialization
	void Start () {
		anim = Animator.GetComponent<Animator>();
		anim.SetBool("isHappyRunning",true);
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Wait();
	}

	void Move(){
		if(ShouldMove == true){
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, CurrentCheckpoint.position, step);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Launcher"){
			anim.SetBool("isHappyRunning",false);
			anim.SetBool("isHappyIdle",true);
			StartCoroutine(WaitAndPrint(2.5F));
		}
		if(col.gameObject.tag == "Wait"){
			isWaiting = true;
			print ("onlyOnce");
		}
	}
	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		anim.SetBool("isHappyIdle",false);
		anim.SetBool("isHappyJumping",true);
		speed = 2;
		this.rigidbody.AddForce(transform.up * Time.deltaTime * 30000);
		yield return new WaitForSeconds(0.4f);
		anim.SetBool("isHappyRunning",true);
		anim.SetBool("isHappyJumping",false);
		yield return new WaitForSeconds(0.2f);
		Earthqauke.rigidbody.isKinematic = false;
		Earthqauke.audio.Play();
	}

	void Wait(){
		if(isWaiting == true){
			anim.SetBool("isHappyRunning",false);
			anim.SetBool("isHappyIdle",true);
			CurrentCheckpoint = myTransform;
		}
		if(StopWaiting == true){
			isWaiting = false;
			anim.SetBool("isHappyRunning",true);
			anim.SetBool("isHappyIdle",false);
			CurrentCheckpoint = Checkpoint7;
		}
	}

	void NotWaiting(){
	
	}
}
