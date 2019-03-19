using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour {
	public string tileName;
	public int baseDefense;
	public string description;
	public int fundsPerTurn;

	private TerrainMovementCost movementCost;

	void Start() {
		movementCost = GetComponent<TerrainMovementCost> ();
	}

	public int MovementCostFor(MovementType type) {
		return movementCost.MovementCostFor (type);
	}
}