using UnityEngine;
using System.Collections;

public class GameManagerScr : MonoBehaviour {
	public static GameManagerScr Instance;
	public Color color;

	// Use this for initialization
	void Start () {
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
			GameManagerScr.Instance.color = Color.blue;
		} else if (Instance != this){
			Destroy (gameObject);
		}
		color = GameManagerScr.Instance.color;
	}
	
	public static void setColor(Color newColor){
		GameManagerScr.Instance.color = newColor;

	}
}
