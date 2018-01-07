using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JummperSpider : MonoBehaviour {

	private Rigidbody2D myBody;
	private Animator anim;
	private float forceY;

	void Awake(){
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		StartCoroutine (Attach());
	}

	IEnumerator Attach(){
		yield return new WaitForSeconds (Random.Range(2,7));
		forceY = Random.Range (250,550);
		myBody.AddForce (new Vector2(0,forceY));
		anim.SetBool ("isAttacking",true);

		StartCoroutine (Attach());
	}

	void OnTriggerEnter2D(Collider2D target){
	
		if (target.gameObject.tag=="Ground") {
			anim.SetBool ("isAttacking",false);
		}

		if (target.gameObject.tag=="Player") {
			Destroy (target.gameObject);
		}
	}
}
