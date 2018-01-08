using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

	public float TimeDownStep=1,time=20f;
	private GameObject player;
	private Slider slider;

	// Use this for initialization
	void Awake () {
		slider = GameObject.Find("Time Slider").GetComponent<Slider>();

		player = GameObject.Find ("Player");

		slider.maxValue = time;
		slider.value = slider.maxValue;
	}
	
	// Update is called once per frame
	void Update () {
		if (!player) {
			return;
		}
		if (time > 0) {
			time -= TimeDownStep * Time.deltaTime;
			slider.value = time;
		} else {
			Destroy (player);
			GetComponent<GameController> ().PlayerDied ();
		}
	}
}
