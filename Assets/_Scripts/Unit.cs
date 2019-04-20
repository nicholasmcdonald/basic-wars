using UnityEngine;

public class Unit : MonoBehaviour, IDailyActor {
    [SerializeField]
    private UnitStats stats;

    private int currentGas;

    public void OnTurnStart()
    {

    }

    public void OnSpawn()
    {

    }

    public static bool Spawn(GameObject unitPrefab, Vector2Int position)
    {
        MapTile targetTile = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().GetMapTileAt(position);
        if (targetTile.Occupant != null)
            return false;
        else
        {
            Unit newUnit = Instantiate(unitPrefab, targetTile.WorldPosition, Quaternion.identity).GetComponent<Unit>();
            targetTile.Occupant = newUnit;
            newUnit.OnSpawn();
            return true;
        }
    }

	public Vector2Int Position {
		get {
			int row = (int)(transform.position.y);
			int column = (int)(transform.position.x);
			return new Vector2Int (column, row);
		}
	}

    public bool CanMoveIntoTile(MapTile tile)
    {
        int movementCost = tile.Terrain.MovementCost[stats.MovementType];
        return stats.MovementPoints >= movementCost && currentGas >= movementCost;
    }
}
