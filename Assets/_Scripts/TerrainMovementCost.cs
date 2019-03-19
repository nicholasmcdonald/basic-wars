using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovementCost : MonoBehaviour {
	public int infantry;

	public int MovementCostFor(MovementType type) {
		switch (type) {
		case MovementType.Infantry:
			return infantry;
		default:
			return 0;
		}
	}
}
