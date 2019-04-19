using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Custom/Unit Data")]
public class UnitStats : ScriptableObject
{
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

    public string UnitName { get { return unitName; } }
    public int MovementPoints { get { return movementPoints; } }
    public int MaxGas { get { return maxGas; } }
    public int DailyGasConsumption { get { return dailyGasConsumption; } }
    public MovementType MovementType { get { return movementType; } }
}