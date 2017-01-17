using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public int health;
	public int exp;
	public int strength;
	public int speed;

	public Slider healthSlider;
	public Slider expSlider;
	public Slider strengthSlider;
	public Slider speedSlider;


	void Start ()   
	{
		health = GameManagerScr.Instance.health;
		exp = GameManagerScr.Instance.exp;
		strength = GameManagerScr.Instance.strength;
		speed = GameManagerScr.Instance.speed;
	}
		
	
	// Update is called once per frame
	void Update () {

		UpdateSlider ();
		SaveData ();
	}

	void SaveData(){
		GameManagerScr.Instance.health = health;
		GameManagerScr.Instance.exp = exp;
		GameManagerScr.Instance.strength = strength;
		GameManagerScr.Instance.speed = speed;
	}

	void UpdateSlider(){
		healthSlider.value = health;
		expSlider.value = exp;
		strengthSlider.value = strength;
		speedSlider.value = speed;
	}
}
