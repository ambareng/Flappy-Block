
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int currentScore;
	public int highScore;
	public Text currentScoreText;
	public Text highScoreText;
	public float scoreCooldown;
	public int scored = 0;

	private PauseManager pauseManager;
	private FlappyBlockController flappyController;

	void Awake () {
		scoreCooldown = 2f;
		pauseManager = FindObjectOfType<PauseManager> ();
		flappyController = FindObjectOfType<FlappyBlockController> ();
		currentScore = 0;
		highScore = PlayerPrefs.GetInt ("Highscore", 0);
		highScoreText.text = "Highscore: " + highScore.ToString ();
	}

	void FixedUpdate () {
		if (pauseManager.gameStart) {
			scoreCooldown -= Time.deltaTime;

			if (scoreCooldown < 0) {
				currentScore += 1;

				scored += 1;

				if (scored == 5) {
					scored = 0;
					scoreCooldown -= 1f;
					flappyController.speed += 1f;
				}

				scoreCooldown = 2f;
			}

			currentScoreText.text = "Score: " + currentScore.ToString ();

			if (currentScore > highScore) {
				highScore = currentScore;
				highScoreText.text = "Highscore: " + highScore.ToString ();
				PlayerPrefs.SetInt ("Highscore", highScore);
			}
		}
	}

}
