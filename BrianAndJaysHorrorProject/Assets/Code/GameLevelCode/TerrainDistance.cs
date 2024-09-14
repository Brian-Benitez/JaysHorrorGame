
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainDistance : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        CreateChunk(collision);
    }
    /// <summary>
    /// This may not work well if the player walks backwards, but for now ill use it
    /// </summary>
    /// <param name="collider"></param>
    public void CreateChunk(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("a hit");
            FindObjectOfType<GameManager>().GenerateNewTerrain();//hopfully this isnt slow!
        }
    }
}
