using UnityEngine;
using UnityEngine.Tilemaps;

public class OverlayManager : MonoBehaviour
{
    [SerializeField]
    private Map map;
    [SerializeField]
    private TileBase tile;

    /**
     * Paint a NavMap as an overlay of the terrain map, with the tile colour
     * determined by the MapActionState.
     */
    public void PaintOverlay(NavMap navMap, MapActionState state)
    {
        SetTileColour(state);
        PaintTiles(navMap);
    }

    private void PaintTiles(NavMap navMap)
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        for (int row = 0; row < map.Rows; row++)
        {
            for (int column = 0; column < map.Columns; column++)
            {
                if (navMap[row, column] == true)
                    tilemap.SetTile(new Vector3Int(row, column, 0), tile);
                else
                    tilemap.SetTile(new Vector3Int(row, column, 0), null);
            }
        }
    }

    private void SetTileColour(MapActionState state)
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        switch (state)
        {
            case MapActionState.NoSelection: tilemap.color = Color.clear; break;
        }
    }
}
