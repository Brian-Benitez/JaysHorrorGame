
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDistance : MonoBehaviour
{
    public TerrainGenerator Generator;
    public Transform TerrainSpawnPoint;

    private void OnTriggerEnter(Collider collision)
    {
        Check(collision);//rename and clean..
    }
    //this need more work...
    public void Check(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           Generator.GenerateNewTerrain(TerrainSpawnPoint);
        }
        else
        {
            Debug.Log("Do not generate new terrain");
        }
    }
}
