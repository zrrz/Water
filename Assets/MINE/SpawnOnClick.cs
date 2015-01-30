using UnityEngine;
using System.Collections;

public class SpawnOnClick : MonoBehaviour {

	public GameObject[] spawnables;

	int curSelection = 0;

	GameObject curObject;

	void Start () {
		curObject = (GameObject)Instantiate (spawnables [curSelection]);
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			curSelection--;
			if(curSelection < 0) {
				curSelection = spawnables.Length - 1;
				Destroy(curObject);
				curObject = (GameObject)Instantiate (spawnables [curSelection]);
			}
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			curSelection++;
			if(curSelection > spawnables.Length - 1) {
				curSelection = 0;
				Destroy(curObject);
				curObject = (GameObject)Instantiate (spawnables [curSelection]);
			}
		}

		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit)) {
			curObject.transform.position = hit.point;

			if (Input.GetButtonDown ("Fire1")) {
				curObject.transform.parent = hit.transform.parent;
				curObject = (GameObject)Instantiate (spawnables [curSelection]);
			}
		}
	}
}
