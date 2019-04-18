using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrain", menuName = "Custom/Terrain")]
public class TerrainStats : ScriptableObject
{
    [SerializeField]
    private string terrainName;
    [SerializeField]
    private int baseDefense;
    [SerializeField]
    private string description;
    [SerializeField]
    private List<MovementType> movementCostKey;
    [SerializeField]
    private List<int> movementCostValue;

    private Dictionary<MovementType, int> movementCost;

    void OnEnable()
    {
        movementCost = new Dictionary<MovementType, int>();
        if (movementCostKey.Count == movementCostValue.Count)
            for (int i = 0; i < movementCostKey.Count; i++)
                movementCost.Add(movementCostKey[i], movementCostValue[i]);
        else
            throw new System.Exception("Failed to load TerrainStats " + terrainName + " because there are unpaired MovementCost entries!");
    }
}
