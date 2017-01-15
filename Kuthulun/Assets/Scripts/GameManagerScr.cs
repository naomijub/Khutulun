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

	// Use this for initialization
	void Awake () {
		go = GameObject.FindGameObjectWithTag ("Player");
		if (Instance == null) {
			Instance = this;
			GameManagerScr.Instance.lastScene = 0;
			GameManagerScr.Instance.playerPos = go.transform.position;
			DontDestroyOnLoad (GameManagerScr.Instance);
		} 
	}

	void Start(){
		currentScene = SceneManager.GetActiveScene ();
		anim = go.GetComponent<Animator> ();

		if(currentScene.buildIndex == 0 && GameManagerScr.Instance.lastScene != 0){
			go.GetComponent<PlayerController> ().enabled = true;
			go.transform.position = GameManagerScr.Instance.playerPos - new Vector3(0f, 1f, 0f);
			anim.SetTrigger ("walkDown");
			GameManagerScr.Instance.lastScene = 0;
		} else if (currentScene.buildIndex == 1) {
			go.GetComponent<PlayerController> ().enabled = false;
			go.transform.position = new Vector3 (-4.5f, 1.7f, -1.0f);
			GameManagerScr.Instance.lastScene = 1;
		} else if (currentScene.buildIndex == 2) {
			go.GetComponent<PlayerController> ().enabled = true;
			go.transform.position = new Vector3 (0f, -1.7f, -1.0f);
			anim.SetTrigger ("walkUp");
			GameManagerScr.Instance.lastScene = 2;
		}
	}

	void Update(){
		if (currentScene.buildIndex == 0) {
			GameManagerScr.Instance.playerPos = go.transform.position;
		}
	}

}
