using UnityEngine;

public class Unit : MonoBehaviour, IDailyActor {
    [SerializeField]
    private string unitName;
    [SerializeField]
    private int movementPoints;
    [SerializeField]
    private int maxGas;
    [SerializeField]
    private int dailyGasConsumption;
    [SerializeField]
    private MovementType movementType;

    private int currentGas;

    public void OnTurnStart()
    {

    }

	public Vector2Int Position {
		get {
			int row = (int)(transform.position.y);
			int column = (int)(transform.position.x);
			return new Vector2Int (column, row);
		}
	}

    //public bool CanMoveDistance(int distance)
    //{
    //    return currentMovementPoints >= distance
    //        && gas >= (distance * gasMovementConsumption);
    //}
}
