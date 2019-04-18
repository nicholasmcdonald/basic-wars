using UnityEngine;

public class MapTile {
	public Unit Occupant { get; set; }
	public TerrainStats Terrain { get; private set; }
	public Vector2Int MapPosition { get; private set; }
    public Vector3 WorldPosition {
        get {
            return new Vector3(MapPosition.x + 0.5f, MapPosition.y + 0.5f, 0.0f);
        }
    }

    public MapTile(TerrainStats terrain, Vector2Int position)
    {
        Terrain = terrain;
        MapPosition = position;
    }
}
