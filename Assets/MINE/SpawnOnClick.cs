using UnityEngine;
using System.Collections;

public class SpawnOnClick : MonoBehaviour {

	public GameObject[] spawnables;

	int curSelection = 0;

	GameObject curObject;

//	public LayerMask mask;

	void Start () {
		curObject = (GameObject)Instantiate (spawnables [curSelection]);
		SetLayer("Ignore Raycast");
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			curSelection--;
			if(curSelection < 0) {
				curSelection = spawnables.Length - 1;
			}
			Destroy(curObject);
			curObject = (GameObject)Instantiate (spawnables [curSelection]);
			SetLayer("Ignore Raycast");
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			curSelection++;
			if(curSelection > spawnables.Length - 1) {
				curSelection = 0;
			}
			DestroyImmediate(curObject);
			curObject = (GameObject)Instantiate (spawnables [curSelection]);
			SetLayer("Ignore Raycast");
		}
		Camera cam = GetComponentInChildren<Camera> ();
		RaycastHit hit;
		if (Physics.Raycast (cam.ScreenPointToRay (new Vector3(Screen.width/2f,Screen.height/2f)), out hit)) {
			curObject.transform.position = hit.point;

			if (Input.GetButtonDown ("Fire1")) {
				SetLayer("Default");
				curObject.transform.parent = hit.transform.parent;
				curObject = (GameObject)Instantiate (spawnables [curSelection], hit.point, Quaternion.identity);
				SetLayer("Ignore Raycast");
			}
		}
	}

	void SetLayer(string layer) {
		curObject.layer = LayerMask.NameToLayer (layer);
		foreach (Transform obj in curObject.GetComponentsInChildren<Transform>()) {
			obj.gameObject.layer = LayerMask.NameToLayer (layer);
		}
	}
}
