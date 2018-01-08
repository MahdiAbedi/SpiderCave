using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject pausePanel;
	public Button pauseButton;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void GoToMenu(){
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenu");
	}

	public void PlayerDied(){
		Time.timeScale = 0f;
		pausePanel.SetActive (true);

	}

	public void Resume(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void Restart(){
		Time.timeScale = 0f;
		Application.LoadLevel ("MainMenu");
	}
}
