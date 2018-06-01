
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBlockController : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb;
	public float upwardForce;
	public float gravityForce;
	public bool isInvincible;
	public float powerupTime;

	private PauseManager pauseManager;

	void Awake () {
		isInvincible = false;
		powerupTime = 0f;
		pauseManager = FindObjectOfType<PauseManager> ();
		rb.gravityScale = 0f;
	}

	void LateUpdate () {
		if (this.transform.position.y >= 8 || this.transform.position.y <= -8) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

		if (!pauseManager.gameStart) {
			rb.gravityScale = 0f;
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}

		if (pauseManager.gameStart) {
			rb.constraints = RigidbodyConstraints2D.None;
			rb.gravityScale = gravityForce;
			transform.Translate (speed * Time.deltaTime, 0f, 0f);

			if (Input.GetMouseButtonDown (0)) {
				rb.velocity = new Vector2 (0, upwardForce * Time.deltaTime);
			}

			if (isInvincible) {
				powerupTime = 10f;
				this.gameObject.layer = 9;
				isInvincible = false;
			}

			powerupTime -= Time.deltaTime;

			if (powerupTime <= 0) {
				this.gameObject.layer = 0;
			}
		}
	}

}
