using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FightManagerScr : MonoBehaviour {
	public GameObject go;
	Scene currentScene;

	void Awake(){
		currentScene = SceneManager.GetActiveScene ();
	}


	// Use this for initialization
	void OnTriggerEnter2D(){
		go.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		go.GetComponent<Animator> ().SetTrigger ("lookRight");
		go.GetComponent<PlayerFightController> ().enabled = true;
	}

	void OnTriggerStay2D(){
		if (currentScene.buildIndex == 1) {
			go.GetComponent<PlayerController> ().enabled = false;
			go.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			go.GetComponent<Animator> ().SetTrigger ("lookRight");
			go.GetComponent<PlayerFightController> ().enabled = true;
		}
	}

	void OnTriggerExit2D(){
		go.GetComponent<PlayerFightController> ().enabled = false;
	}
}
