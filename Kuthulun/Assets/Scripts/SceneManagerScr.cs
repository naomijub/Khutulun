using UnityEngine;
using System.Collections;

public class SceneManagerScr : MonoBehaviour {
	public GameObject go;
	public Camera cam;
	Animator anim;
	GameManagerScr gmScr;

	// Use this for initialization
	void Awake () {
		go.GetComponent<PlayerController> ().enabled = false;
		go. transform.position = new Vector3 (-4.5f, 1.7f, -1.0f);
		anim = go.GetComponent<Animator> ();
		anim.SetTrigger ("walkRight");
		gmScr = GetComponent<GameManagerScr> ();
		cam.backgroundColor = gmScr.color;
	}
		
	// Update is called once per frame
	void Update () {
	
	}
}
