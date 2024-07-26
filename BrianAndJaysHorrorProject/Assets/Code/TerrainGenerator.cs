using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Transform SpawnPoint;
    public List<GameObject> Terrains;

    public void GenerateNewTerrain()
    {
        //Not sure if we wanna randomly pick a terrain to pick.
        Instantiate(Terrains[0], SpawnPoint);
    }
}
