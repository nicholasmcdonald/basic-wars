using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	public string unitName;
	public int movementRange;
	public int gas;
	public int gasMovementConsumption;
	public int gasDailyConsumption;
	public MovementType movementType;

	public Vector3Int Position {
		get {
			int row = (int)(transform.position.y);
			int column = (int)(transform.position.x);
			return new Vector3Int (column, row, 0);
		}
	}

	public int CurrentMovementPoints {
		get {
			return currentMovementPoints;
		}
	}

	private int currentMovementPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool CanMoveDistance(int distance) {
		return currentMovementPoints >= distance 
			&& gas >= (distance * gasMovementConsumption);
	}
}
