using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorActivator : MonoBehaviour {
	// Use this for initialization
	public int sceneIdx;
	public Color color;

	
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("loading scene");
		GameManagerScr.setColor (color);
		SceneManager.LoadScene (sceneIdx); 
	}
}
