using UnityEngine;

public class NavMap : MonoBehaviour
{
    private bool[,] grid;
    private Map map;

    public bool this[int row, int column]
    {
        get { return grid[row, column]; }
    }

    void Start()
    {
        this.map = GetComponent<Map>();
        grid = new bool[map.rows, map.columns];
    }

    /**
     * Make all areas of the map accessible.
     **/
    public void GenerateBasicNav()
    {
        for (int row = 0; row < map.rows; row++)
        {
            for (int column = 0; column < map.columns; column++)
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
}
