using UnityEngine;
using System.Collections;

public class PuzzleManager : MonoBehaviour {

	public PuzzlePiece heldPiece;

	public LayerMask pieceMask;
	public LayerMask moveMask;
	public LayerMask placeMask;

	void Start () {
	
	}
	
	void Update () {
		if(heldPiece != null) {
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f, moveMask)) {
				heldPiece.transform.position = hit.point;
			}
		}

		if(Input.GetButtonDown("Fire1")) {
			if(heldPiece != null) {
				RaycastHit hit;
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f, placeMask)) {
					heldPiece.transform.parent = hit.collider.transform;
					heldPiece.transform.localPosition = Vector3.zero;
					heldPiece = null;
				}
			} else {
				RaycastHit hit;
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f, pieceMask)) {
					PuzzlePiece piece = hit.collider.GetComponent<PuzzlePiece>();
					heldPiece = piece.GetPiece();
					heldPiece.transform.parent = null;
					heldPiece.transform.localScale = hit.collider.transform.localScale;
				}
			}
		}
	}
}
