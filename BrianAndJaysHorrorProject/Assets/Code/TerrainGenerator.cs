using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [Header("Transforms")]
    public Transform SpawnPoint;
    public List<Transform> Terrains;

    [Header("Vars")]
    public int TerrainIndex;

    public void GenerateNewTerrain()
    {
       Transform objectS = Instantiate(Terrains[0], SpawnPoint);
        Debug.Log("ahh");
    }
}
