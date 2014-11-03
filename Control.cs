using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour{
	public int playerNumber = 1;
	public float speed = 20f;
	public float jumpSpeed = 8f;
	public float gravity = 20f;

	private Vector3 moveDirection = Vector3.zero;
	private Vector3 faceDirection = Vector3.zero;

	private CharacterController charController;

	private bool mobile = true;

	void Start(){
		charController = gameObject.GetComponentInChildren<CharacterController>();
	}

	void Update(){
		if(mobile){
			faceDirection = GetInputVector();
			if(charController.isGrounded){
				moveDirection = GetInputVector();
				if(moveDirection.magnitude != 0f){
					Turn();
				}

				moveDirection *= speed;

				if(GetPlayerButton("Jump")){
					Jump();
				}
			}
			// Apply gravity
			moveDirection.y -= 3 * gravity * Time.deltaTime;
			// Move the character controller
			charController.Move(moveDirection * Time.deltaTime);

			Debug.DrawRay(
					transform.position,
					faceDirection,
					Color.green);
		}
	}

	void Turn(){
		transform.rotation = Quaternion.LookRotation(
				faceDirection,
				Vector3.up);
		moveDirection = transform.forward;
	}

	void Jump(){
		moveDirection.y = jumpSpeed;
	}

	Vector3 GetInputVector(){
		return new Vector3(
				GetPlayerAxis("Horizontal"),
				0,
				GetPlayerAxis("Vertical"));
	}

	float GetPlayerAxis(string axis){
		return Input.GetAxis("P"+playerNumber+" "+axis);
	}

	bool GetPlayerButton(string button){
		return Input.GetButton("P"+playerNumber+" "+button);
	}

	public bool Mobile(){
		return mobile;
	}

	public bool Mobile(bool state){
		mobile = state;
		return mobile;
	}
}
