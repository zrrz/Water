using UnityEngine;
using System.Collections;

public class SpotGizmos : MonoBehaviour {
	void OnDrawGizmos() {
		for (int i = 0; i < transform.childCount; i++) {
			Gizmos.color = Color.red;
			Gizmos.DrawRay(transform.GetChild(i).position, Vector3.up);
		}
	}
}
