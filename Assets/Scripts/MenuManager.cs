using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public void LoadScene (string sceneName){
		Application.LoadLevel (sceneName);

	}
}
