
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

	public bool gameStart = false;
	public Text prompt;

	void Awake () {
		prompt.enabled = true;
	}

	void Update () {
		if (Input.touches.Length > 1 && gameStart || Input.GetKeyDown (KeyCode.P)) {
			gameStart = false;
			prompt.enabled = true;
			Debug.Log ("Paused");
		}

		if (Input.GetMouseButtonDown (0) && !gameStart) {
			prompt.enabled = false;
			gameStart = true;
		}
	}

}
