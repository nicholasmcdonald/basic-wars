using UnityEngine;

public class MapTile : MonoBehaviour {
	public string Type {
		get {
			return terrain.name;
		}
	}

	public Unit Occupant { get; set; }

	private Vector3Int position;
	private TerrainTile terrain;
	// building

	public void SetTerrain(TerrainTile terrain) {
		this.terrain = terrain;
	}

	public void SetPosition(Vector3Int position) {
		this.position = position;
	}

	public int GetMovementCostFor(Unit unit) {
		return terrain.MovementCostFor (unit.movementType);
	}
}
