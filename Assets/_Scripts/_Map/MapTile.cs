using UnityEngine;

public class MapTile {
	public Unit Occupant { get; set; }
	public TerrainStats Terrain { get; private set; }
	public Vector2Int MapPosition { get; private set; }
    public Vector3 WorldPosition { get; private set; }

    public MapTile(TerrainStats terrain, Vector3 worldPosition)
    {
        Terrain = terrain;
        WorldPosition = worldPosition;
        MapPosition = new Vector2Int((int)worldPosition.x, (int)worldPosition.y);
    }
}
