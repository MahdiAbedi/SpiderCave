using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	private Transform player;

	public float minX,maxX;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (player!=null) {
			Vector3 temp = transform.position;
			temp.x = player.position.x;
			temp.y = player.position.y+3f;
			temp.x=Mathf.Clamp (temp.x,minX,maxX);

			transform.position = temp;
		}
	}
}
