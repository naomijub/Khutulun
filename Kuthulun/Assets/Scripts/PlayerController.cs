using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb2d;
	Animator anim;
	enum Dir {up, down, left, right }

	public float speed = 96.0f;
	Dir dir = Dir.down;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float y = Input.GetAxis("Vertical");
		float x = Input.GetAxis("Horizontal");

		rb2d.velocity = new Vector2 (x , y ) * speed * Time.deltaTime;

		Animations (x, y);

	}
		
	public void Animations(float x, float y){
		if (y < 0 && x == 0 && dir != Dir.down) {
			anim.SetTrigger ("walkDown");
			dir = Dir.down;
		} else if (y > 0 && x == 0 && dir != Dir.up) {
			anim.SetTrigger ("walkUp");
			dir = Dir.up;
		} else if (x > 0 && y == 0 && dir != Dir.right) {
			anim.SetTrigger ("walkRight");
			dir = Dir.right;
		} else if (x < 0 && y == 0 && dir != Dir.left) {
			anim.SetTrigger ("walkLeft");
			dir = Dir.left;
		}
	}

}
