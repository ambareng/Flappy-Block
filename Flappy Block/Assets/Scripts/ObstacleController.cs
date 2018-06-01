
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleController : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Flappy") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

}
