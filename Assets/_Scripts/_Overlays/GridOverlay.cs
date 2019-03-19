using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridOverlay : MonoBehaviour {
	public GameObject cursor;

	private int rows;
	private int columns;
	private int cursorRow;
	private int cursorColumn;
	private Map map;

	void Start () {
		AlignGridWithMap ();
		SetGridDimensions ();
		SetCursorStartPosition ();
	}
	
	void Update () {
		int horizontalMovement = (int)Input.GetAxisRaw ("Horizontal");
		if (horizontalMovement != 0) {
			cursorColumn += horizontalMovement;
			if (cursorColumn < 0)
				cursorColumn = 0;
			if (cursorColumn >= columns)
				cursorColumn = columns - 1;
			PositionCursor ();
		}

		int verticalMovement = (int)Input.GetAxisRaw ("Vertical");
		if (verticalMovement != 0) {
			cursorRow += verticalMovement;
			if (cursorRow < 0)
				cursorRow = 0;
			if (cursorRow >= rows)
				cursorRow = rows - 1;
			PositionCursor ();
		}

		if (Input.GetKeyUp(KeyCode.Return)) {
			Debug.Log(map.GetMapTileAt(cursorRow, cursorColumn).Type);
		}
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

	void SetCursorStartPosition() {
		cursorRow = 0;
		cursorColumn = 0;
		PositionCursor ();
	}

	void PositionCursor() {
		cursor.transform.localPosition = new Vector2 (cursorColumn + 0.5f, cursorRow + 0.5f);
	}
}