using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerScr : MonoBehaviour {
	public static GameManagerScr Instance;
	public GameObject go;
	public Vector3 playerPos;
	public int lastScene;
	Animator anim;
	Scene currentScene;

	public int health;
	public int exp;
	public int strength;
	public int speed;

	// Use this for initialization
	void Awake () { 
		if (Instance == null) {
			Instance = this;
			GameManagerScr.Instance.lastScene = 0;
			Debug.Log (GameManagerScr.Instance.playerPos + " " + go.transform.position);
			GameManagerScr.Instance.playerPos = go.transform.position;
			DontDestroyOnLoad (GameManagerScr.Instance);

			GameManagerScr.Instance.health = 100;
			GameManagerScr.Instance.exp = 1;
			GameManagerScr.Instance.strength = 1;
			GameManagerScr.Instance.speed = 1;
		} 
	}

	void Start(){
		currentScene = SceneManager.GetActiveScene ();
		anim = go.GetComponent<Animator> ();

		if(currentScene.buildIndex == 0 && GameManagerScr.Instance.lastScene != 0){
			go.GetComponent<PlayerController> ().enabled = true;
			go.GetComponent<PlayerFightController> ().enabled = false;
			go.transform.position = GameManagerScr.Instance.playerPos - new Vector3(0f, 1f, 0f);
			anim.SetTrigger ("walkDown");
			GameManagerScr.Instance.lastScene = 0;
		} else if (currentScene.buildIndex == 1) {
			go.GetComponent<PlayerController> ().enabled = true;
			go.GetComponent<PlayerFightController> ().enabled = false;
			go.transform.position = new Vector3 (0f, -1.7f, -1.0f);
			anim.SetTrigger ("walkUp");
			GameManagerScr.Instance.lastScene = 1;
		} else if (currentScene.buildIndex == 2) {
			go.GetComponent<PlayerController> ().enabled = true;
			go.GetComponent<PlayerFightController> ().enabled = false;
			go.transform.position = new Vector3 (5f, 0.25f, -1.0f);
			anim.SetTrigger ("walkUp");
			GameManagerScr.Instance.lastScene = 2;
		} else if (currentScene.buildIndex == 3) {
			go.GetComponent<PlayerController> ().enabled = true;
			go.GetComponent<PlayerFightController> ().enabled = true;
			go.transform.position = new Vector3 (0f, -2.5f, -1.0f);
			anim.SetTrigger ("walkUp");
			GameManagerScr.Instance.lastScene = 3;
		} else if (currentScene.buildIndex == 4) {
			//Miyagi Ring
			go.GetComponent<PlayerController> ().enabled = false;
			go.GetComponent<PlayerFightController> ().enabled = true;
			transform.position = new Vector3 (-4.5f, 1.7f, -1.0f);
			GameManagerScr.Instance.lastScene = 4;
		} 
	}

	void Update(){
		if (currentScene.buildIndex == 0) {
			GameManagerScr.Instance.playerPos = go.transform.position;
		}
	}

}
