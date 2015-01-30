using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public float speed = 2f;

	public LayerMask mask;

	public Shader waterShader;

	void Start () {
//		camera.RenderWithShader(waterShader
		GetComponent<BlurEffect> ().enabled = false;
	}
	
	void Update () {
		Vector3 dir = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Lateral"), Input.GetAxis ("Vertical"));

		transform.position += dir * speed * Time.deltaTime;

		Vector3 point = camera.ViewportToWorldPoint (new Vector3(Screen.width / 2.0f, 0f));

//		float distance = (camera.ViewportToWorldPoint (new Vector3 (Screen.width / 2.0f, Screen.height)) - point).magnitude;

//		RaycastHit hit;
//
//		if (Physics.Raycast (new Ray (point, -transform.up), out hit, distance, mask)) {
//			renderer.material.SetFloat("WaterHeight", hit.distance);
//		}

//		Plane[] planes = GeometryUtility.CalculateFrustumPlanes (camera);

//		planes[0].
	}

	void WaterEnter() {
		GetComponent<BlurEffect> ().enabled = true;
	}

	void WaterExit() {
		GetComponent<BlurEffect> ().enabled = false;
	}
}
