using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	
	private int[,] board = new int[8, 8] {
		{2,3,4,5,6,4,3,2},
		{1,1,1,1,1,1,1,1},
		{0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0},
		{1,1,1,1,1,1,1,1},
		{2,3,4,5,6,4,3,2}
	};
	
	private List<GameObject> cells = new List<GameObject>();
	
	void OnMouseDown () {
		Debug.Log(Mathf.FloorToInt(Input.mousePosition.x).ToString() + " :: " + Mathf.FloorToInt(Input.mousePosition.z).ToString());
		
	}
	
	void InitEnvironment () {
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				GameObject cell = new GameObject("h" + i.ToString() + "v" + j.ToString());
				cell.transform.position = Vector3.zero;
				cell.transform.localPosition = new Vector3(i, transform.localScale.y / 2 + 0.1f, j);
				cells.Add(cell);
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		InitEnvironment();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
