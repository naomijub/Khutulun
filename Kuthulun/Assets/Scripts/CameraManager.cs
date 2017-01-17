using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public Transform target;
	public float smoothing = 0.3f;
	public Vector3 offsetVector = new Vector3(0.0f, 2f, -9.0f);
	public Vector2 upperLimit = new Vector2 (40f, 70f);
	public Vector2 lowerLimit = new Vector2 (-41, -71);

	Vector3 offset;

	void Awake(){
		transform.position = target.position + offsetVector;
		offset = transform.position - target.position + new Vector3 (0f, 0f, -1f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos;

		if (target.position.x > upperLimit.x && target.position.y > upperLimit.y) {
			targetCamPos = new Vector3 (upperLimit.x + 1f, upperLimit.y + 1f, target.position.z) + offset;
			smoothing = 0.8f;
		} else if (target.position.x > upperLimit.x && target.position.y < lowerLimit.y) {
			targetCamPos = new Vector3 (upperLimit.x + 1f, lowerLimit.y - 1f, target.position.z) + offset;
			smoothing = 0.8f;
		} else if (target.position.x < lowerLimit.x && target.position.y > upperLimit.y) {
			targetCamPos = new Vector3 (lowerLimit.x - 1f, upperLimit.y + 1f, target.position.z) + offset;
			smoothing = 0.8f;
		} else if (target.position.x < lowerLimit.x && target.position.y < lowerLimit.y) {
			targetCamPos = new Vector3 (lowerLimit.x - 1f, lowerLimit.y - 1f, target.position.z) + offset;
			smoothing = 0.8f;
		} else if (target.position.y > upperLimit.y) {
			targetCamPos = new Vector3 (target.position.x, upperLimit.y + 1f, target.position.z) + offset;
			smoothing = 0.8f;
		} else if (target.position.x > upperLimit.x) {
			targetCamPos = new Vector3 (upperLimit.x + 1f, target.position.y, target.position.z) + offset;
			smoothing = 0.8f;
		} else if (target.position.x < lowerLimit.x) {
			targetCamPos = new Vector3 (lowerLimit.x - 1f, target.position.y, target.position.z) + offset;
			smoothing = 0.8f;
		} else if (target.position.y < lowerLimit.y) {
			targetCamPos = new Vector3 (target.position.x, lowerLimit.y - 1f, target.position.z) + offset;
			smoothing = 0.8f;
		} else {
			targetCamPos = target.position + offset;
			smoothing = 2.0f;
		}

		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
