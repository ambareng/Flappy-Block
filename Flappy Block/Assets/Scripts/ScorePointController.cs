
using UnityEngine;

public class ScorePointController : MonoBehaviour {

	private ScoreManager scoreManager;
	private bool hasScored;

	void Awake () {
		scoreManager = FindObjectOfType<ScoreManager> ();
		hasScored = false;
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Flappy") {
			hasScored = false;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Flappy") {
			hasScored = false;
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Flappy" && !hasScored) {
			Debug.LogWarning ("SCORED!!");
			scoreManager.currentScore += 1;
			hasScored = true;
		}
	}

}
