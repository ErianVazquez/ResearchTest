using UnityEngine;
using System.Collections;

public class PlayerEventController : MonoBehaviour {

	public GameObject patient;

	public GameObject hips;

	public GameObject leftShoulder;
	public GameObject leftArm;
	public GameObject leftArmRoll;
	public GameObject leftForeArmRoll;
	public GameObject rightShoulder;
	public GameObject rightArm;
	public GameObject rightArmRoll;
	public GameObject rightForeArmRoll;

	public Vector3 rightArmRotationIdle;
	public Vector3 rightArmRotationAngle;
	public Vector3 rightArmRollRotationAngle;
	public Vector3 rightForeArmRollRotationAngle;
	public Vector3 leftArmRotationIdle;

	public int state = -1;

	float lerpTime = 1f;
	float currentLerpTime;

	// Use this for initialization
	void Start () {
		currentLerpTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (state == -1) { //Before Start
			if(Input.GetButtonDown("YButton")){
				state++;
				rightArmRotationIdle = rightArm.transform.eulerAngles;
				leftArmRotationIdle = leftArm.transform.eulerAngles;
			}
		} else if (state == 0) { // Right Arm

			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime) {
				currentLerpTime = lerpTime;
			}

			if (currentLerpTime < lerpTime) {
				float perc = currentLerpTime / lerpTime;
				rightArm.transform.eulerAngles = new Vector3 (Mathf.Lerp (rightArm.transform.eulerAngles.x, 0, perc),
					Mathf.Lerp (rightArm.transform.eulerAngles.y, 180, perc),
					Mathf.Lerp (rightArm.transform.eulerAngles.z, 20, perc));

				rightArmRotationAngle = rightArm.transform.eulerAngles;
				rightArmRollRotationAngle = rightArmRoll.transform.eulerAngles;
				rightForeArmRollRotationAngle = rightForeArmRoll.transform.eulerAngles;
			}
			
			if(Input.GetButton("RotateArmClockwise")){
				rightArmRotationAngle.x -= 1;
				rightArmRollRotationAngle.x -= 1;
				rightForeArmRollRotationAngle.x -= 1;
			}
			if(Input.GetButton("RotateArmCounterClockwise")){
				rightArmRotationAngle.x += 1;
				rightArmRollRotationAngle.x += 1;
				rightForeArmRollRotationAngle.x += 1;
			}

//			rightArm.transform.eulerAngles = rightArmRotationAngle;
			rightArmRoll.transform.eulerAngles = rightArmRollRotationAngle;
			rightForeArmRoll.transform.eulerAngles = rightForeArmRollRotationAngle;

			//Go To Next State
			if(Input.GetButtonDown("YButton")){
				state++;
				currentLerpTime = 0f;
				print ("enter");
			}
		} else if (state == 1) { // Left Arm


			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime) {
				currentLerpTime = lerpTime;
			}

			if (currentLerpTime < lerpTime) {
				float perc = currentLerpTime / lerpTime;
				rightArm.transform.eulerAngles = new Vector3 (Mathf.Lerp (rightArm.transform.eulerAngles.x, rightArmRotationIdle.x, perc),
					Mathf.Lerp (rightArm.transform.eulerAngles.y, rightArmRotationIdle.y, perc),
					Mathf.Lerp (rightArm.transform.eulerAngles.z, rightArmRotationIdle.z, perc));

				leftArm.transform.eulerAngles = new Vector3 (Mathf.Lerp (leftArm.transform.eulerAngles.x, 0, perc),
					Mathf.Lerp (leftArm.transform.eulerAngles.y, 180, perc),
					Mathf.Lerp (leftArm.transform.eulerAngles.z, 200, perc));
			}

			if(Input.GetButton("RotateArmClockwise")){

			}
			if(Input.GetButton("RotateArmCounterClockwise")){

			}


			//Go To Next State
			if(Input.GetButtonDown("YButton")){
				state++;
				currentLerpTime = 0f;
				print ("enter");
			}
		} else if (state == 2) { // Face

			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime) {
				currentLerpTime = lerpTime;
			}

			if (currentLerpTime < lerpTime) {
				float perc = currentLerpTime / lerpTime;

				leftArm.transform.eulerAngles = new Vector3 (Mathf.Lerp (leftArm.transform.eulerAngles.x, leftArmRotationIdle.x, perc),
					Mathf.Lerp (leftArm.transform.eulerAngles.y, leftArmRotationIdle.y, perc),
					Mathf.Lerp (leftArm.transform.eulerAngles.z, leftArmRotationIdle.z, perc));
			}


			//Go To Next State
			if(Input.GetButtonDown("YButton")){
				state++;
				currentLerpTime = 0f;
				print ("enter");
			}

		} else if (state == 3) { // Neck

			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime) {
				currentLerpTime = lerpTime;
			}

			if (currentLerpTime < lerpTime) {
				float perc = currentLerpTime / lerpTime;

				hips.transform.eulerAngles = new Vector3 (Mathf.Lerp (hips.transform.eulerAngles.x, 270, perc),
					Mathf.Lerp (hips.transform.eulerAngles.y, 270, perc),
					Mathf.Lerp (hips.transform.eulerAngles.z, 0, perc));
			}

		}
	}
}
