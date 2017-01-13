using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager Instance;

	public int health;
	public int exp;
	public int strength;
	public int speed;

	public Slider healthSlider;
	public Slider expSlider;
	public Slider strengthSlider;
	public Slider speedSlider;


	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject.GetComponent<PlayerManager>());
			Instance = this;
			PlayerManager.Instance.health = 100;
			PlayerManager.Instance.exp = 0;
			PlayerManager.Instance.strength = 0;
			PlayerManager.Instance.speed = 0;
		}
		else if (Instance != this)
		{
			Destroy (gameObject.GetComponent<PlayerManager>());
		}
	}

	// Use this for initialization
	void Start () {
		health = PlayerManager.Instance.health;
		exp = PlayerManager.Instance.exp;
		strength = PlayerManager.Instance.strength;
		speed = PlayerManager.Instance.speed;	
	}
	
	// Update is called once per frame
	void Update () {

		UpdateSlider ();
		SaveData ();
	}

	void SaveData(){
		PlayerManager.Instance.health = health;
		PlayerManager.Instance.exp = exp;
		PlayerManager.Instance.strength = strength;
		PlayerManager.Instance.speed = speed;
	}

	void UpdateSlider(){
		healthSlider.value = health;
		expSlider.value = exp;
		strengthSlider.value = strength;
		speedSlider.value = speed;
	}
}
