using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Door.instance.CollectablesCount++;
		Debug.Log ("Diamonds="+Door.instance.CollectablesCount);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag=="Player") {
			Destroy (gameObject);
			Door.instance.DecreaseCollectablesCount ();
		}
	}
}
