
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainDistance : MonoBehaviour
{
    public int AmountOfExcutions = 0;

    private void OnTriggerEnter(Collider collision)
    {
        //CreateChunk(collision);
    }
    /// <summary>
    /// This may not work well if the player walks backwards, but for now ill use it
    /// </summary>
    /// <param name="collider"></param>
    public void CreateChunk(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (AmountOfExcutions == 0)
            {
                FindObjectOfType<TerrainGenerator>().GenerateNewTerrain();//hopfully this isnt slow!
                AmountOfExcutions++;   
            }
            else
                return;
        }
        else if (!collider.gameObject.CompareTag("Player"))
            AmountOfExcutions = 0;
    }
}
