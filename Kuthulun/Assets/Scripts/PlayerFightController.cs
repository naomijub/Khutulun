using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerFightController : MonoBehaviour {
	Animator anim;
	public GameObject gameManager;
	public GameObject EnemyObj;
	List<Move> auxMoves;
	Scene currentScene;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
	    auxMoves = gameManager.GetComponent<MovesList> ().moves;
	}

	void Start(){
		currentScene = SceneManager.GetActiveScene ();
	}

	void Update(){
		Commands (Input.inputString);
	}

	void Commands (string input){
		if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5") {
			MakeMove (input);
		}
	}

	void MakeMove(string input){
		int moveIdx = int.Parse (input) - 1;
		if (auxMoves [moveIdx].Available) {
			if (currentScene.buildIndex == 3) {
				Move (auxMoves [moveIdx].AnimName);
				UpdateStats (moveIdx);
			} else {
				Move (auxMoves [moveIdx].AnimName);
				EnemyObj.GetComponent<EnemyManager> ().TakeDamage (auxMoves [moveIdx].Damage);
				this.enabled = false;
				StartCoroutine_Auto(Hold (1.5f));
			}
		}
	}

	IEnumerator Hold(float time){
		yield return new WaitForSeconds (time);
		this.enabled = true;
		Debug.Log ("Player enabled");
	}


	public void Move(string triggerName){
		anim.SetTrigger (triggerName);
	}

	void UpdateStats(int moveIdx){
		UpdateStrength (moveIdx);
		UpdateSpeed (moveIdx);
	}

	void UpdateSpeed(int moveIdx){
		if (moveIdx == 1 || moveIdx == 3 || moveIdx == 4) {
			if (gameObject.GetComponent<PlayerManager> ().speed < 100) {
				gameObject.GetComponent<PlayerManager> ().speed += moveIdx * 2;
			} else {
				if (gameObject.GetComponent<PlayerManager> ().exp < 100) {
					gameObject.GetComponent<PlayerManager> ().speed = gameObject.GetComponent<PlayerManager> ().exp;
					gameObject.GetComponent<PlayerManager> ().exp += 3;
				}
			}
		}
	}

	void UpdateStrength(int moveIdx){
		if (moveIdx == 0 || moveIdx == 2 || moveIdx == 4) {
			if (gameObject.GetComponent<PlayerManager> ().strength < 100) {
				gameObject.GetComponent<PlayerManager> ().strength += (moveIdx + 1) * 2;
			} else {
				if (gameObject.GetComponent<PlayerManager> ().exp < 100) {
					gameObject.GetComponent<PlayerManager> ().strength = gameObject.GetComponent<PlayerManager> ().exp;
					gameObject.GetComponent<PlayerManager> ().exp += 3;
				}
			}
		}
	}
}
