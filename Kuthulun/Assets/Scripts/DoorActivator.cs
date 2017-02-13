using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorActivator : MonoBehaviour {
	// Use this for initialization
	public int sceneIdx;

	
	void OnTriggerEnter2D(Collider2D col){
		SceneManager.LoadScene (sceneIdx); 
	}
}
