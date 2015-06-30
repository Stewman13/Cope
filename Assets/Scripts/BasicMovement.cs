using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {

	public GameObject GroundDetector;
	public IsGrounded _grounded;

	//animation things
	public GameObject Animator;
	public Animator anim;


	public float ShakeAmount = 0.05f;
	public float CurrentShakeAmount = 0.0f;

	public float StandardJump;
	public float AngryJump;
	public float RunSpeed;
	public float WalkSpeed;
	public Vector3 MaxSpeed;
	public float Gravity;
	public Rigidbody rb;

	public bool setAngryRunning;
	public bool setAngryJumping;
	public bool setHappyRunning;
	public bool setHappyJumping;

	public float jumpAnimTimer;
	public float remainingCooldownTime;
	public bool keyIsUp = true;
	public bool isJumping = false;
	public bool jumpCooldown = false;
	public bool isAngry = false;
	public bool canJump = false;
	public bool atMaxSpeed = false;
	public bool onGround;
	public bool onLeftWall;
	public bool onRightWall;
	public bool onHead;
	public bool facingRight = true;

	private CameraShake _shake;
	
	// Use this for initialization
	void Start () {
		anim = Animator.GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		_shake = Camera.main.GetComponent<CameraShake>();
		_grounded = GroundDetector.GetComponent<IsGrounded> ();
	}

	void Update () {
		if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow)){
			keyIsUp = true;
		}
		if (rigidbody.velocity.y <= -13.0f) {
			_grounded.shouldShake = true;
		}
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (jumpCooldown == true) {
			remainingCooldownTime -= Time.fixedDeltaTime;
			if(remainingCooldownTime <= 0 && keyIsUp == true){
				jumpCooldown = false;
			}
		}
		if (isJumping == true) {
			jumpAnimTimer -= Time.fixedDeltaTime;
			if(jumpAnimTimer <= 0){
				isJumping = false;
			}
		}
		AngryMove ();
		Grounded ();
	}

	void AngryMove(){
		rb.AddForce(transform.up * Time.deltaTime * -Gravity);

		if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && canJump == true && onGround == true && jumpCooldown == false){
			keyIsUp = false;
			jumpCooldown = true;
			remainingCooldownTime = 0.1f;
			isJumping = true;
			jumpAnimTimer = 0.5f;
			//angry
			if(isAngry == true){
				anim.SetBool("isAngryIdle",false);
				anim.SetBool("isHappyIdle",false);
				anim.SetBool("isAngryRunning",false);
				anim.SetBool("isAngryJumping",true);
				rb.AddForce(transform.up * Time.deltaTime * AngryJump);
				ShakeAmount = (CurrentShakeAmount + 0.05f);
				_shake.shake = ShakeAmount;
			}
			//happy
			if(isAngry == false){
				CurrentShakeAmount = 0.0f;
				anim.SetBool("isAngryIdle",false);
				anim.SetBool("isHappyIdle",false);
				anim.SetBool("isHappyRunning",false);
				anim.SetBool("isHappyJumping",true);
				rb.AddForce(transform.up * Time.deltaTime * StandardJump);
				ShakeAmount = CurrentShakeAmount;
				_shake.shake = ShakeAmount;
			}
		}
		else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && onGround == false && onLeftWall == true && onRightWall == false && jumpCooldown == false){
			keyIsUp = false;
			jumpCooldown = true;
			remainingCooldownTime = 0.1f;
			isJumping = true;
			jumpAnimTimer = 0.5f;
			//angry 
			if(isAngry == true){
				FlipLeft();
				anim.SetBool("isAngryIdle",false);
				anim.SetBool("isHappyIdle",false);
				anim.SetBool("isAngryJumping",true);
				anim.SetBool("isAngryRunning",false);
				rb.AddForce(transform.up * Time.deltaTime * AngryJump / 1.1f);
				rb.AddForce(transform.right * Time.deltaTime * 500000);
				ShakeAmount = (CurrentShakeAmount + 0.01f);
				_shake.shake = ShakeAmount;
			}
			//happy
			if(isAngry == false){
				CurrentShakeAmount = 0.0f;
				FlipLeft();
				anim.SetBool("isAngryIdle",false);
				anim.SetBool("isHappyIdle",false);
				anim.SetBool("isHappyJumping",true);
				anim.SetBool("isHappyRunning",false);
				rb.AddForce(transform.right * Time.deltaTime * 50000);
				ShakeAmount = CurrentShakeAmount;
				_shake.shake = ShakeAmount;
			}
		}
		else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))&& onGround == false && onLeftWall == false && onRightWall == true && jumpCooldown == false){
			keyIsUp = false;
			jumpCooldown = true;
			remainingCooldownTime = 0.1f;
			isJumping = true;
			jumpAnimTimer = 0.5f;
			//angry
			if(isAngry == true){
				FlipRight();
				anim.SetBool("isAngryIdle",false);
				anim.SetBool("isHappyIdle",false);
				anim.SetBool("isAngryJumping",true);
				anim.SetBool("isAngryRunning",false);
				rb.AddForce(transform.up * Time.deltaTime * AngryJump / 1.1f);
				rb.AddForce(transform.right * Time.deltaTime * -500000);
				ShakeAmount = (CurrentShakeAmount + 0.01f);
				_shake.shake = ShakeAmount;
			}
			//happy
			if(isAngry == false){
				CurrentShakeAmount = 0.0f;
				FlipRight();
				anim.SetBool("isAngryIdle",false);
				anim.SetBool("isHappyIdle",false);
				anim.SetBool("isHappyJumping",true);
				anim.SetBool("isHappyRunning",false);
				rb.AddForce(transform.right * Time.deltaTime * -50000);
				ShakeAmount = (CurrentShakeAmount + 0.01f);
				_shake.shake = ShakeAmount;
			}
		}


		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			//angry
			if(isAngry == true){
				FlipRight();
				if(setAngryJumping == false && onGround == true){
					anim.SetBool("isAngryIdle",false);
					anim.SetBool("isHappyIdle",false);
					anim.SetBool("isAngryRunning",true);
					setAngryRunning = true;
				}
				else if(onGround == false){
					anim.SetBool("isAngryIdle",false);
					anim.SetBool("isHappyIdle",false);
					anim.SetBool("isAngryRunning",false);
					anim.SetBool("isAngryJumping",false);
				}
				if(atMaxSpeed == false){
					rb.AddForce (transform.right * Time.deltaTime * -RunSpeed, ForceMode.Acceleration);
				}
				if(rb.velocity.x <= -20){
					atMaxSpeed = true;
				}
				if(rb.velocity.x > -20){
					atMaxSpeed = false;
				}
			}
			//happy
			if(isAngry == false){
				FlipRight();
				if(setHappyJumping == false && onGround == true){
					anim.SetBool("isAngryIdle",false);
					anim.SetBool("isHappyIdle",false);
					anim.SetBool("isHappyRunning",true);
					setHappyRunning = true;
				}
				else if(onGround == false){
					anim.SetBool("isAngryIdle",false);
					anim.SetBool("isHappyIdle",false);
					anim.SetBool("isHappyRunning",false);
					anim.SetBool("isHappyJumping",false);
				}
				if(atMaxSpeed == false){
					rb.AddForce (transform.right * Time.deltaTime * -WalkSpeed, ForceMode.Acceleration);
				}
				if(rb.velocity.x <= -20){
					atMaxSpeed = true;
				}
				if(rb.velocity.x > -20){
					atMaxSpeed = false;
				}
			}
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			//angry
			if(isAngry == true){
				FlipLeft();
				if(setAngryJumping == false  && onGround == true){
					anim.SetBool("isAngryIdle",false);
					anim.SetBool("isHappyIdle",false);
					anim.SetBool("isAngryRunning",true);
					setAngryRunning = true;
				}
				else if(onGround == false){
					anim.SetBool("isAngryRunning",false);
					anim.SetBool("isAngryJumping",false);
				}
				if(atMaxSpeed == false){
					rb.AddForce (transform.right * Time.deltaTime * RunSpeed, ForceMode.Acceleration);
				}
				if(rb.velocity.x >= 20){
					atMaxSpeed = true;
				}
				if(rb.velocity.x < 20){
					atMaxSpeed = false;
				}
			}
			//happy
			if(isAngry == false){
				FlipLeft();
				if(setAngryJumping == false  && onGround == true){
					anim.SetBool("isAngryIdle",false);
					anim.SetBool("isHappyIdle",false);
					anim.SetBool("isHappyRunning",true);
					setHappyRunning = true;
				}
				else if(onGround == false){
					anim.SetBool("isAngryIdle",false);
					anim.SetBool("isHappyIdle",false);
					anim.SetBool("isHappyRunning",false);
					anim.SetBool("isHappyJumping",false);
				}
				if(atMaxSpeed == false){
					rb.AddForce (transform.right * Time.deltaTime * WalkSpeed, ForceMode.Acceleration);
				}
				if(rb.velocity.x >= 20){
					atMaxSpeed = true;
				}
				if(rb.velocity.x < 20){
					atMaxSpeed = false;
				}
			}
		}
		else{
			if(isAngry == true && onGround == true && isJumping == false){
				anim.SetBool("isAngryIdle",true);
				anim.SetBool("isHappyIdle",false);
				anim.SetBool("isAngryJumping",false);
				anim.SetBool("isAngryRunning",false);
				anim.SetBool("isHappyJumping",false);
				anim.SetBool("isHappyRunning",false);
				setAngryJumping = false;
				setAngryRunning = false;
				setHappyJumping = false;
				setHappyRunning = false;
			}	
			if(isAngry == false){
				anim.SetBool("isAngryIdle",false);
				anim.SetBool("isHappyIdle",true);
				anim.SetBool("isAngryJumping",false);
				anim.SetBool("isAngryRunning",false);
				anim.SetBool("isHappyJumping",false);
				anim.SetBool("isHappyRunning",false);
				setHappyJumping = false;
				setHappyRunning = false;
				setAngryJumping = false;
				setAngryRunning = false;
			}
		}
	}

	void FlipLeft(){
		if(facingRight == true){
			facingRight = false;
			// Multiply the player's x local scale by -1
			Vector2 theScale = Animator.transform.localScale;
			theScale.x *= -1;
			Animator.transform.localScale = theScale;
			print ("facingLeft");
		}
	}

	void FlipRight(){
		if(facingRight == false){
			facingRight = true;
			// Multiply the player's x local scale by -1
			Vector2 theScale = Animator.transform.localScale;
			theScale.x *= -1;
			Animator.transform.localScale = theScale;
			print ("facingRight");
		}
	}

	void Grounded(){
		if (onGround == false) {
			canJump = false;
			Gravity = 50000;
		}
		else if (onGround == true){
			canJump = true;
			Gravity = 0;
		}
	}
}
