
using UnityEngine;

public class DestructionController : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D col) {
		Destroy (col.gameObject);
	}

}
