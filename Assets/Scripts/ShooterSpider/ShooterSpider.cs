using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSpider : MonoBehaviour {


	[SerializeField]
	private GameObject bullet;

	void Start(){
		StartCoroutine (ShootBullet());
	}

	IEnumerator ShootBullet(){
		Instantiate (bullet,transform.position,Quaternion.identity);
		yield return new WaitForSeconds (Random.Range(2,5));

		StartCoroutine (ShootBullet());
	}

	void OnTriggerEnter2D(Collider2D target){
	
		if (target.tag=="Player") {
			Destroy (target.gameObject);	
		}
	}
}
