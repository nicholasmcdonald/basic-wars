using System.Collections.Generic;
using UnityEngine;

public class TerrainHost : MonoBehaviour
{
    [SerializeField]
    private List<string> terrainType;
    [SerializeField]
    private List<TerrainStats> terrainData;
    private Dictionary<string, TerrainStats> terrain;

    /**
     * THIS IS ONLY INTENDED TO BE USED WITH THE NAME PROPERTY OF A TILEBASE OBJECT
     * I SWEAR TO GOD DON'T TYPE A LITERAL INTO THIS
     */
    public TerrainStats this[string type]
    {
        get { return terrain[type]; }
    }

    void Start()
    {
        terrain = new Dictionary<string, TerrainStats>();
        if (terrainType.Count == terrainData.Count)
            for (int i = 0; i < terrainType.Count; i++)
                terrain.Add(terrainType[i], terrainData[i]);
        else
            throw new System.Exception("Failed to construct TerrainHost because there are unpaired TerrainType entries!");
    }
}
