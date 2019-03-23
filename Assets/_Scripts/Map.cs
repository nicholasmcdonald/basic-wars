using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour, SelectionStateObserver {
	public int rows;
	public int columns;
	public MapTile mapTilePrefab;

	private List<List<MapTile>> map;

	void Start() {
		GenerateMapDataStructures ();
		SetSpawnedOccupancies ();
	}

	private void GenerateMapDataStructures() {
		Tilemap tilemap = GetComponent<Tilemap> ();
		Transform terrainHolder = GameObject.FindGameObjectWithTag ("Terrain").transform;

		map = new List<List<MapTile>> ();
		for (int i = 0; i < rows; i++) {
			List<MapTile> currentRow = new List<MapTile> ();
			map.Add (currentRow);
			for (int j = 0; j < columns; j++) {
				MapTile currentTile = Instantiate (mapTilePrefab, transform) as MapTile;
				Transform currentTerrain = terrainHolder.Find (tilemap.GetTile (new Vector3Int (j, i, 0)).name);
				currentTile.SetTerrain (currentTerrain.GetComponent<TerrainTile>());
				currentRow.Add (currentTile);
			}
		}
	}

	private void SetSpawnedOccupancies() {
		foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit")) {
			int row = (int)(unit.transform.position.y);
			int column = (int)(unit.transform.position.x);

			map [row] [column].SetOccupant (unit.GetComponent<Unit>());
		}
	}

	public MapTile GetMapTileAt(int row, int column) {
		return map [row] [column];
	}

	public bool CheckBoundsFor(int row, int column) {
		return (row >= 0 && row < rows && column >= 0 && column < columns);
	}

    public void ChangeSelectionState(SelectionState newSelcetionState)
    {
        // Tell the navmap
    }
}