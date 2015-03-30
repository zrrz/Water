using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour {

	public PuzzlePiece heldPiece;

	public LayerMask pieceMask;
	public LayerMask moveMask;
	public LayerMask placeMask;

	[HideInInspector]
	public int score;
	public int turns;

	public Text scoreText, turnsText;

	void Start() {
		UpdateGUI ();
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
					if(hit.collider.transform.childCount == 0) {
						heldPiece.transform.parent = hit.collider.transform;
						heldPiece.transform.localPosition = Vector3.zero;
						if(heldPiece.type == PuzzlePiece.Type.OVAL)
							ChangeScore(2);
						else
							ChangeScore(1);
						heldPiece = null;
						ReduceTurns();
					}
				} else if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f, pieceMask)) {
					PuzzlePiece piece = hit.collider.GetComponent<PuzzlePiece>();
					if(piece.type == heldPiece.type) {
						Destroy(heldPiece.gameObject);
					}
				}
			} else {
				RaycastHit hit;
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f, pieceMask)) {
					PuzzlePiece piece = hit.collider.GetComponent<PuzzlePiece>();
					heldPiece = piece.GetPiece();
					if(piece == heldPiece) {
						ReduceTurns();
						if(heldPiece.type == PuzzlePiece.Type.OVAL)
							ChangeScore(-2);
						else
							ChangeScore(-1);
					} else {

					}
					heldPiece.transform.parent = null;
					heldPiece.transform.localScale = hit.collider.transform.localScale;
				}
			}
		}
	}

	void UpdateGUI() {
		scoreText.text = score.ToString();
		turnsText.text = turns.ToString();
	}

	void ChangeScore(int points) {
		score += points;
		UpdateGUI ();
	}

	void ReduceTurns() {
		turns--;
		UpdateGUI ();
		if (turns < 0)
			GameOver ();
	}

	void GameOver() {

	}
}
