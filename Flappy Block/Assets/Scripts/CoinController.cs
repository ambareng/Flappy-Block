
using UnityEngine;

public class CoinController : MonoBehaviour {

	private ScoreManager scoreManager;

	void Awake () {
		scoreManager = FindObjectOfType<ScoreManager> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Flappy") {
			scoreManager.currentScore += 5;
			Destroy (this.gameObject);
		}
	}

}
