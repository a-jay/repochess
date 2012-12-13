using UnityEngine;
using System.Collections;

public class MarineController : MonoBehaviour {
	
	private bool isSelected = false;
	
	private const float rotationSpeed = 0.5f;
	private const float rotationAngle = 10f;
	private int rotationSteps = (int)(rotationAngle / rotationSpeed);
	private bool rotationDirection = false;	//	true == right
	private Vector2 currentPosition;
	private Vector3 startRotation;
	
	// Use this for initialization
	void Start () {
		startRotation = transform.eulerAngles;
		currentPosition = new Vector2(transform.position.x, transform.position.z);
	}
	
	void RotateMe () {
		transform.Rotate(new Vector3(0, (rotationDirection ? rotationSpeed : -rotationSpeed), 0 ));
		rotationSteps++;
		
		if (rotationSteps > rotationAngle * 2 / rotationSpeed) {
			rotationSteps = 0;
			rotationDirection = !rotationDirection;
		}
	}
	
	void RotateToZero () {
		transform.Rotate(new Vector3(0, (rotationDirection ? -rotationSpeed : rotationSpeed), 0 ));
		if ((int)transform.eulerAngles.y == 0) {
			rotationDirection = false;
		}
	}
	
	void OnMouseDown () {
		if (!GameController.Instance.lockSelection) {
			isSelected = !isSelected;
			
			if (!isSelected) {
				transform.eulerAngles = new Vector3(0, 0, 0);
			}
			else {
				GameController.Instance.isSelected = name;
			}
			
			transform.rigidbody.isKinematic = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isSelected) {
			if (GameController.Instance.isSelected != name) {
				OnMouseDown();
			}
			else {
				if (GameController.Instance.moveTo != new Vector2(-1, -1)) {
					GameController.Instance.LockSelection();
				}
					
				RotateMe();
			}
		}
		else {
			if ((int)transform.eulerAngles.y != 0) {
				RotateToZero();
			}
		}
	}
}
