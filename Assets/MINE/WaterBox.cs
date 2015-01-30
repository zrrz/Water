using UnityEngine;
using System.Collections;

public class WaterBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		print ("water enter");
		col.SendMessage ("WaterEnter");
	}

	void OnTriggerExit(Collider col) {
		col.SendMessage ("WaterExit");
	}
}
