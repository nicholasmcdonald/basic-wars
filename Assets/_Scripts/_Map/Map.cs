using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour {
    private List<List<MapTile>> map;

    public int Rows { get; private set; }
    public int Columns { get; private set; }

	void Start() {
        // Cache map dimensions
        Vector3Int size = GetComponent<Tilemap>().size;
        Rows = size.y;
        Columns = size.x;

        map = new MapGenerator().GenerateMapDataStructures(GetComponent<Tilemap>());
		SetSpawnedOccupancies ();
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