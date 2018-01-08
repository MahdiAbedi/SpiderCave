using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirController : MonoBehaviour {

	public float airDownStep=1,air=20f;
	private GameObject player;
	private Slider slider;

	// Use this for initialization
	void Awake () {
		slider = GameObject.Find("Air Slider").GetComponent<Slider>();
	
		player = GameObject.Find ("Player");

		slider.maxValue = air;
		slider.value = slider.maxValue;
	}

	// Update is called once per frame
	void Update () {
		if (!player) {
			return;
		}
		if (air > 0) {
			air -= airDownStep * Time.deltaTime;
			slider.value = air;
		} else {
			
			Destroy (player);
			GetComponent<GameController> ().PlayerDied ();
		}
	}
}