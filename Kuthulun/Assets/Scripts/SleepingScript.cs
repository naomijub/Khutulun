using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SleepingScript : MonoBehaviour {
	public RawImage nightImg;
	public PlayerManager playerManagerScr;
	public float flashSpeed = 0.6f;
	public float nightTime = 3.5f;
	bool isSleeping;
	float timer = 0f;


	// Use this for initialization
	void Start () {
		isSleeping = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isSleeping) {
			if (timer > 1f) {
				nightImg.color = Color.Lerp (nightImg.color, Color.clear, flashSpeed * Time.deltaTime);
			} else {
				playerManagerScr.health = 100;
			}
			HasEndedSleep ();
		}

	}

	public void HasEndedSleep(){
		timer += Time.deltaTime;
		if (timer >= nightTime) {
			isSleeping = false;
			timer = 0f;
		}
	}

	void OnTriggerEnter2D(){
		isSleeping = true;
		nightImg.color = Color.black;
	}

	void OnTriggerExit2D(){
		nightImg.color = Color.clear;
	}
}
