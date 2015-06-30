using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {

	public GameObject Animator;
	public Animator anim;

	public Transform CurrentCheckpoint;
	public GameObject Checkpoint1;
	public GameObject Checkpoint2;
	public GameObject Checkpoint3;
	public GameObject Checkpoint4;

	public bool ShouldMove = false;

	public GameObject me;
	
	public float speed;
	// Use this for initialization
	void Start () {
		anim = Animator.GetComponent<Animator>();
		anim.SetBool("isHappyRunning",true);
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move(){
		if(ShouldMove == true){
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, CurrentCheckpoint.position, step);
		}
	}
}
