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
}