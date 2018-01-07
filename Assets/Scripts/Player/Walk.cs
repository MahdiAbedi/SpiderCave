using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

	public float moveForce=20f,jumpForce=700f,maxVelocity=4f;

	private Rigidbody2D myBody;
	private Animator anim;

	public float bounceJump=500f;
	private bool grounded=true;

	// Use this for initialization
	void Awake () {
		InitializeVariables ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		PlayerWalkKeyboard ();
	}

	void InitializeVariables(){
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}

	void PlayerWalkKeyboard(){
	
		float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxis ("Horizontal");

		//up key is pressed
		if (h>0) {
			if (vel<maxVelocity) {
				forceX = moveForce;
			}
			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;

			anim.SetBool ("IsWalking",true);
		}
		//down key is pressed
		else if (h<0) {
			if (vel<maxVelocity) {
				forceX = -moveForce;
			}
			Vector3 scale = transform.localScale;
			//Returns the actor's face to the left
			scale.x = -1f;
			transform.localScale = scale;

			anim.SetBool ("IsWalking",true);
		}
		else if (h==0) {
			anim.SetBool ("IsWalking", false);
		}
			

		if (Input.GetKey(KeyCode.Space)) {
			if (grounded) {
				grounded = false;
				forceY = jumpForce;
			}
		}


		myBody.AddForce (new Vector2(forceX,forceY));


	}//end of function


	void OnCollisionEnter2D(Collision2D target){
	
		if (target.gameObject.tag=="Ground") {
			grounded = true;
		}

		if (target.gameObject.tag=="Bouncer") {
			
			myBody.AddForce (new Vector2(0f,bounceJump));
		}
	}

}//end of class
