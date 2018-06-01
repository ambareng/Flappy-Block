
using UnityEngine;
using System.Collections;

public class SpawnPointController : MonoBehaviour {

	private float spawnCooldown = 0f;
	private Vector3 spawnPos;
	private PauseManager pauseManager;
	private IEnumerator coroutine;

	public int spawnChance;
	public GameObject[] obstaclePrefabs;
	public GameObject coinPrefab;
	public GameObject powerupPrefab;
	public int spawnCoinChance;
	public Vector3 offset;

	void Awake () {
		spawnPos = transform.position;
		pauseManager = FindObjectOfType<PauseManager> ();
	}

	void Update () {
		if (pauseManager.gameStart) {
			spawnPos = transform.position;
			spawnCooldown -= Time.deltaTime;

			if (spawnCooldown < 0) {
				spawnChance = Random.Range (0, 3);
				spawnCoinChance = Random.Range (1, 11);
				coroutine = SpawnObstacle (spawnChance);
				if (spawnCoinChance <= 3) {
					StartCoroutine ("SpawnCoin");
				}
				if (spawnCoinChance == 10) {
					StartCoroutine ("SpawnPower");
				}
				StartCoroutine (coroutine);

				spawnCooldown = 2f;
			}
		}
	}

	IEnumerator SpawnObstacle (int spawnChance) {
		GameObject obstacle = Instantiate (obstaclePrefabs[spawnChance], spawnPos, Quaternion.identity);
		obstacle.transform.position = spawnPos;

		yield return new WaitForSeconds (0.1f);
	}

	IEnumerator SpawnCoin () {
		GameObject coin = Instantiate (coinPrefab, spawnPos, Quaternion.identity);
		int spawnWhere = Random.Range (0, 3);

		if (spawnWhere == 0) {
			offset = new Vector3 (3f, 0f, 0f);
		} else if (spawnWhere == 1) {
			offset = new Vector3 (3f, 4f, 0f);
		} else if (spawnWhere == 2) {
			offset = new Vector3 (3f, -4f, 0f);
		}

		coin.transform.position = spawnPos + offset;

		yield return new WaitForSeconds (0.1f);
	}

	IEnumerator SpawnPower () {
		GameObject powerup = Instantiate (powerupPrefab, spawnPos, Quaternion.identity);
		Vector3 offset1 = new Vector3 (4f, 0f, 0f);
		powerup.transform.position = spawnPos + offset1;

		yield return new WaitForSeconds (0.1f);
	}

}
