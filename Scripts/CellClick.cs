using UnityEngine;
using System.Collections;

public class CellClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseDown () {
		Debug.Log(gameObject.name);
		GameController.Instance.moveTo = new Vector2(transform.position.x, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
