using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	private bool rightMouseButtonPressed = false;
	
	private Vector3 lastMousePosition = new Vector3(-1, -1, -1);
	
	private float movementSpeed = 0.001f;
	
	private Vector3 rotateAroundPoint = new Vector3(4, 0, 4);
	
	private Vector3 rotateAroundAxis = new Vector3 (0, 4, 0);
	
	// Use this for initialization
	void Start () {
	
	}
	
	void ProceedRightButton () {
		if (Input.GetMouseButtonDown(1)) {
			rightMouseButtonPressed = true;
			lastMousePosition = Input.mousePosition;
		}
		
		if (Input.GetMouseButtonUp(1)) {
			rightMouseButtonPressed = false;
		}		
	}
	
	void CameraMove () {
		Vector3 delta = -(Input.mousePosition - lastMousePosition) * 0.1f;
		
		if (lastMousePosition != new Vector3(-1, -1, -1)) {
			//Vector3 delta = -(Input.mousePosition - lastMousePosition) * 0.1f;
			//delta = new Vector3();
			//Debug.Log(delta);
			
			//transform.Rotate(new Vector3(delta.y, delta.x, 0));
			
			transform.RotateAround(rotateAroundPoint, rotateAroundAxis, delta.x);
			
		}
		
		//transform.position += transform.eulerAngles.normalized * Input.GetAxis("Vertical") * movementSpeed;
		//transform.position += transform.eulerAngles.normalized * Input.GetAxis("Horizontal") * movementSpeed;
		transform.position += transform.eulerAngles.normalized * Input.GetAxis("Vertical") * movementSpeed;
		transform.position += transform.eulerAngles.normalized * Input.GetAxis("Horizontal") * movementSpeed;
		
		transform.LookAt(rotateAroundPoint);
		
		lastMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
	}
	
	// Update is called once per frame
	void Update () {
		ProceedRightButton();
		
		if (rightMouseButtonPressed) {
			CameraMove();
		}
		
	}
}
