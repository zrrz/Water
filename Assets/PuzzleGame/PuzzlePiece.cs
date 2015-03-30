using UnityEngine;
using System.Collections;

public class PuzzlePiece : MonoBehaviour {

	public bool spawner = false;

	public enum Type {
		BOX, OVAL, CROSS, HEX
	}

	public Type type;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public PuzzlePiece GetPiece() {
		if(!spawner) {
			return this;
		} else {
			PuzzlePiece piece = ((GameObject)Instantiate(gameObject, transform.position, transform.rotation)).GetComponent<PuzzlePiece>();
			piece.type = type;
			piece.spawner = false;
			return piece;
		}
	}
}
