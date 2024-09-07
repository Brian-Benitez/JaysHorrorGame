using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTerrainTextures : MonoBehaviour
{
    [Header("Textures")]
    public Texture SlowTexture, FastTexture, NormalTexture;

    [Header("Scripts")]
    public TerrainGenerator TerrainGeneratorRef;
    public PlayerSpeedController PlayerSpeedControllerRef;

    public Renderer[] Renderer;
    public void ChangeTexturesOfChunk(GameObject chunk)
    {
        for (int i = 0; i < TerrainGeneratorRef.AmountOfChildsInTerrains; i++)
        {
           Renderer[i] = chunk.transform.GetChild(i).GetComponentInChildren<Renderer>();
           if (chunk.transform.rotation.eulerAngles.x == PlayerSpeedControllerRef.FlatSlope)
                Renderer[i].material.SetTexture("NormalTexture" , NormalTexture);
           //Add more here.
        }
    }
}
