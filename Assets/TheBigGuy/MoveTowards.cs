using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {

	public GameObject Animator;
	public Animator anim;

	public Transform CurrentCheckpoint;
	public Transform Checkpoint1;
	public Transform Checkpoint2;
	public Transform Checkpoint3;
	public Transform Checkpoint4;
	public Transform Checkpoint5;
	public Transform Checkpoint6;

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
