using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOverlay : MonoBehaviour {
	public GameObject shadedTilePrefab;

	private Map map;

	void Start() {
		Map map = GameObject.FindGameObjectWithTag ("Map").GetComponent<Map> ();
	}

	//public void DisplayMovementOverlay(Unit unit) {
	//	// Collect all candidates
	//	List<MapTile> candidateTiles = FindCandidateTiles(unit);
	//	// Display candidates
	//	// Hide hud
	//	// Change unit animation
	//}

	//private List<MapTile> FindCandidateTiles(Unit unit) {
	//	Vector3Int origin = unit.Position;

	//	Queue<MapTile> frontier = new Queue<MapTile> ();
	//	List<MapTile> visited = new List<MapTile>();
	//	List<MapTile> candidates = new List<MapTile> ();

	//	// Bypass origin
	//	MapTile startTile = map.GetMapTileAt(origin.y, origin.x);
	//	AddNeighboursToFrontier (frontier, origin);
	//	visited.Add (startTile);

	//	// Do BFS on frontier
	//	while (frontier.Count > 0) {
	//		MapTile currentTile = frontier.Dequeue ();
	//		if (visited.Contains (currentTile))
	//			continue;
	//		else
	//			visited.Add (currentTile);
			
	//		if (!unit.CanMoveDistance (currentTile.GetMovementCostFor (unit)))
	//			continue;
	//		else {
	//			candidates.Add (currentTile);
	//			//AddNeighboursToFrontier(frontier, );
	//		}
				
	//	}

	//	return null;
	//}

	private bool HasBeenChecked;

	private void AddNeighboursToFrontier(Queue<MapTile> frontier, Vector3Int position) {
		int row = position.y;
		int column = position.x;

		// North
		if (map.CheckBoundsFor (row + 1, column))
			frontier.Enqueue (map.GetMapTileAt (row + 1, column));

		// East
		if (map.CheckBoundsFor (row, column + 1))
			frontier.Enqueue (map.GetMapTileAt (row, column + 1));

		// South
		if (map.CheckBoundsFor (row - 1, column))
			frontier.Enqueue (map.GetMapTileAt (row - 1, column));

		// West
		if (map.CheckBoundsFor (row, column - 1))
			frontier.Enqueue (map.GetMapTileAt (row, column - 1));
	}
}