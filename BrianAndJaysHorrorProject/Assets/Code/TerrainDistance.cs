using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDistance : MonoBehaviour
{
    public bool IsHalfWayThere = false;

    public TerrainGenerator Terrain;

    private void OnTriggerEnter(Collider collision)
    {
        Check(collision);//rename and clean..
    }

    public void Check(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            IsHalfWayThere = true;
            Terrain.GenerateNewTerrain();
            Debug.Log("spawn new terrain...");
        }
        else
            IsHalfWayThere = false;
    }
}
