using System.Collections.Generic;
using UnityEngine;

public class NavMap : MonoBehaviour, MapActionStateObserver
{
    [SerializeField]
    private Map map;
    [SerializeField]
    private OverlayManager overlayManager;
    [SerializeField]
    private Cursor cursor;

    private bool[,] grid;
    private MapTile selectedTile;

    public bool this[int row, int column]
    {
        get { return grid[row, column]; }
    }

    void Start()
    {
        grid = new bool[map.Rows, map.Columns];
        GameObject.FindGameObjectWithTag("GameController").GetComponent<MapControlState>().RegisterActionStateObserver(this);
    }

    public void ChangeSelectionState(MapActionState newState)
    {
        // Generate new navmap appropriate for given state
        // then inform OverlayManager
        if (newState == MapActionState.NoSelection)
        {
            // Change unit animation state if necessary
            selectedTile = null;
            GenerateBasicNav();
        }
        else if (newState == MapActionState.Movement)
        {
            Debug.Log("Selection state engaged!");
            selectedTile = cursor.HoveredTile;
        }

        overlayManager.PaintOverlay(this, newState);
    }

    /**
     * Make all areas of the map accessible.
     **/
    public void GenerateBasicNav()
    {
        for (int row = 0; row < map.Rows; row++)
        {
            for (int column = 0; column < map.Columns; column++)
            {
                grid[row, column] = true;
            }
        }
    }

    /**
     * Only allow tiles the selected unit can visit this turn.
     **/
    public void GenerateMovementNav(Unit selectedUnit)
    {
        ClearNavMap();
        Vector2Int origin = selectedUnit.Position;

        Queue<MapTile> frontier = new Queue<MapTile>();
        List<MapTile> visited = new List<MapTile>();
        List<MapTile> candidates = new List<MapTile>();

        // Bypass origin
        MapTile startTile = map.GetMapTileAt(origin);
        AddNeighboursToFrontier(frontier, origin);
        visited.Add(startTile);

        // Do BFS on frontier
        while (frontier.Count > 0)
        {
            MapTile currentTile = frontier.Dequeue();
            if (visited.Contains(currentTile))
                continue;
            else
                visited.Add(currentTile);

            if (!selectedUnit.CanMoveIntoTile(currentTile))
                continue;
            else
            {
                candidates.Add(currentTile);
                //AddNeighboursToFrontier(frontier, );
            }

            //	}

            //	return null;
        }
    }

    private void AddNeighboursToFrontier(Queue<MapTile> frontier, Vector2Int position)
    {
        int row = position.y;
        int column = position.x;

        // North
        if (map.CheckBoundsFor(row + 1, column))
            frontier.Enqueue(map.GetMapTileAt(new Vector2Int(row + 1, column)));

        // East
        if (map.CheckBoundsFor(row, column + 1))
            frontier.Enqueue(map.GetMapTileAt(new Vector2Int(row, column + 1)));

        // South
        if (map.CheckBoundsFor(row - 1, column))
            frontier.Enqueue(map.GetMapTileAt(new Vector2Int(row - 1, column)));

        // West
        if (map.CheckBoundsFor(row, column - 1))
            frontier.Enqueue(map.GetMapTileAt(new Vector2Int(row, column - 1)));
    }

    /**
     * Only allow tiles the selected unit can attack right now.
     * This nav is used during the Attack SelectionState.
     **/
    public void GenerateAttackNav(Unit selectedUnit)
    {

    }

    /**
     * Only allow tiles into which the selected unit can unload transported units.
     **/
    public void GenerateUnloadNav(Unit selectedUnit)
    {

    }

    /**
     * Only allow tiles the selected unit could potentially attack this turn.
     * This nav is not used during the Attack SelectionState.
     */
    public void GenerateThreatNav(Unit selectedUnit)
    {

    }

    private void ClearNavMap()
    {
        for (int row = 0; row < map.Rows; row++)
            for (int column = 0; column < map.Columns; column++)
                grid[row, column] = false;
    }
}
