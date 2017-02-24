using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorActivator : MonoBehaviour {
	// Use this for initialization
	public int sceneIdx;
	public GameObject player;

	
	void OnTriggerEnter2D(Collider2D col){
		if (player.GetComponent<PlayerManager> ().health > 0) {
			SceneManager.LoadScene (sceneIdx); 
		}
	}
}
