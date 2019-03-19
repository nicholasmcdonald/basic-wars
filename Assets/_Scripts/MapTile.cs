using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour {
	public string Type {
		get {
			return terrain.name;
		}
	}

	public string Occupant {
		get {
			return unit.unitName;
		}
	}

	private Vector3Int position;
	private TerrainTile terrain;
	private Unit unit;
	// building

	public void SetTerrain(TerrainTile terrain) {
		this.terrain = terrain;
	}

	public void SetOccupant(Unit unit) {
		this.unit = unit;
	}

	public void SetPosition(Vector3Int position) {
		this.position = position;
	}

	public int GetMovementCostFor(Unit unit) {
		return terrain.MovementCostFor (unit.movementType);
	}
}
