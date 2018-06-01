
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform targetToFollow;

	void LateUpdate () {
		transform.position = new Vector3 (targetToFollow.position.x + (3), transform.position.y, transform.position.z);
	}

}
