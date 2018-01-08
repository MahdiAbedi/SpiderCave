using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSpider : MonoBehaviour {


	[SerializeField]
	private Transform startPos, endPos;

	private bool isCollisitionWithGround;

	private Rigidbody2D myBody;

	public float speed=1f;

	void Awake(){
		myBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
		ChangeDirection ();
	}

	void ChangeDirection(){
		isCollisitionWithGround = Physics2D.Linecast (startPos.position,endPos.position,1<<LayerMask.NameToLayer("Ground"));

		Debug.DrawLine (startPos.position,endPos.position,Color.green);

		if (!isCollisitionWithGround) {
			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;
		}
	}

	void Move(){
		myBody.velocity = new Vector2 (transform.localScale.x,0) * speed;
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag=="Player") {
			Destroy (target.gameObject);
			GameObject.Find("GameController").GetComponent<GameController> ().PlayerDied ();
		}
	}
}
