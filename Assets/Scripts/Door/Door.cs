using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public static Door instance;

	private Animator anim;

	private BoxCollider2D box;

	[HideInInspector]
	public int CollectablesCount;

	// Use this for initialization
	void Awake () {
		MakeInstance ();
		anim = GetComponent<Animator> ();
		box = GetComponent<BoxCollider2D> ();
	}

	void MakeInstance(){
		if (instance==null) {
			instance = this;
		}
	}
	// Update is called once per frame
	void Update () {
		if (CollectablesCount==0) {
			anim.Play ("OpenDoor");
			box.isTrigger = true;
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag=="Player") {
			Debug.Log ("Game Finnished");
		}
	}
	public void DecreaseCollectablesCount(){
		CollectablesCount--;
		Debug.Log ("Diamonds="+CollectablesCount);
	}
}
