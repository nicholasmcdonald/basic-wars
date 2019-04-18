using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour {
    [SerializeField]
    private TerrainHost terrainHost;

    private List<List<MapTile>> map;

    public int Rows { get; private set; }
    public int Columns { get; private set; }

	void Start() {
        // Cache map dimensions
        Vector3Int size = GetComponent<Tilemap>().size;
        Rows = size.y;
        Columns = size.x;

        GenerateMapDataStructures ();
		SetSpawnedOccupancies ();
	}

	private void GenerateMapDataStructures() {
		Tilemap tilemap = GetComponent<Tilemap> ();
		Transform terrainHolder = GameObject.FindGameObjectWithTag ("Terrain").transform;

		map = new List<List<MapTile>> ();
		for (int i = 0; i < Rows; i++) {
			List<MapTile> currentRow = new List<MapTile> ();
			map.Add (currentRow);
			for (int j = 0; j < Columns; j++) {
                string terrainName = tilemap.GetTile(new Vector3Int(j, i, 0)).name;
                TerrainStats localTerrain = terrainHost[terrainName];
                MapTile currentTile = new MapTile(localTerrain, transform.position);
                currentRow.Add (currentTile);
			}
		}
	}

	private void SetSpawnedOccupancies() {
		foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit")) {
			int row = (int)(unit.transform.position.y);
			int column = (int)(unit.transform.position.x);

			map [row] [column].Occupant = unit.GetComponent<Unit>();
		}
	}

	public MapTile GetMapTileAt(int row, int column) {
		return map [row] [column];
	}

    /**
     * Returns true if the passed coordinate is within the map
     */
	public bool CheckBoundsFor(int row, int column) {
		return (row >= 0 && row < Rows && column >= 0 && column < Columns);
	}

    public bool CheckBoundsFor(Vector2 tile)
    {
        return (tile.y >= 0 && tile.y < Rows && tile.x >= 0 && tile.x < Columns);
    }
}