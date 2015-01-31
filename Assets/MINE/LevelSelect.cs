using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	static LevelSelect s_instance;

	void Start () {
		if (s_instance == null) {
			s_instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if (Application.loadedLevel != 0) {
				Application.LoadLevel("Intro");
				transform.GetChild (0).gameObject.SetActive (true);
			}
		}
	}
	
	public void StartAdventure() {
		Application.LoadLevel ("wateradventuregame");
		transform.GetChild (0).gameObject.SetActive (false);
	}

	public void StartSandbox() {
		Application.LoadLevel ("Main");
		transform.GetChild (0).gameObject.SetActive (false);
	}
}
