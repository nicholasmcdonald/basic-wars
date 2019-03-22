using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridOverlay : MonoBehaviour {
	private int rows;
	private int columns;
	private Map map;

	void Start () {
		AlignGridWithMap ();
		SetGridDimensions ();
	}
	
	void Update () {
	/*	if (Input.GetKeyUp(KeyCode.Return)) {
			Debug.Log(map.GetMapTileAt(cursorRow, cursorColumn).Type);
		} */
	}

	/* The grid origin is set to the bottom left corner */
	void AlignGridWithMap() {
		transform.position = new Vector2 (0, 0);
		map = GameObject.FindGameObjectWithTag ("Map").GetComponent<Map> ();
	}

	void SetGridDimensions() {
		rows = map.rows;
		columns = map.columns;
	}
}