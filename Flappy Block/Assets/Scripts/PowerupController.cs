
using UnityEngine;

public class PowerupController : MonoBehaviour {

	private FlappyBlockController flappyBlockController;

	void Awake () {
		flappyBlockController = FindObjectOfType<FlappyBlockController> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Flappy") {
			flappyBlockController.isInvincible = true;
			Destroy (this.gameObject);
		}
	}

}
