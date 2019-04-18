using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator
{
    public List<List<MapTile>> GenerateMapDataStructures(Tilemap tilemap)
    {
        Vector3Int mapSize = tilemap.size;
        TerrainHost terrainHost = GameObject.FindGameObjectWithTag("Data").GetComponent<TerrainHost>();

        List<List<MapTile>> mapData = new List<List<MapTile>>();
        for (int y = 0; y < mapSize.y; y++)
        {
            List<MapTile> currentRow = new List<MapTile>();
            mapData.Add(currentRow);
            for (int x = 0; x < mapSize.x; x++)
            {
                string terrainName = tilemap.GetTile(new Vector3Int(x, y, 0)).name;
                TerrainStats localTerrain = terrainHost[terrainName];
                MapTile currentTile = new MapTile(localTerrain, new Vector2Int(x,y));
                currentRow.Add(currentTile);
            }
        }

        return mapData;
    }
}
