using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public Transform target;
	public float smoothing = 2.0f;

	Vector3 offset;

	// Use this for initialization
	void Start () {

		offset = transform.position - target.position + new Vector3(0.0f, -2.0f, 2.0f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos;

		if (target.position.y > 70.0f) {
			targetCamPos = new Vector3 (target.position.x, 71.0f, target.position.z) + offset;
			smoothing = 0.8f;
		} else if (target.position.x > 40.0f) {
			targetCamPos = new Vector3 (42.0f, target.position.y, target.position.z) + offset;
			smoothing = 0.8f;
		} else if (target.position.x < -41.0f) {
			targetCamPos = new Vector3 (-43.0f, target.position.y, target.position.z) + offset;
			smoothing = 0.8f;
		} else {
			targetCamPos = target.position + offset;
			smoothing = 2.0f;
		}
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
