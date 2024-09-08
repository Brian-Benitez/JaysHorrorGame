using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTerrainTextures : MonoBehaviour
{
    [Header("Textures")]
    public Material SlowTexture, FastTexture, NormalTexture;
    

    [Header("Scripts")]
    public TerrainGenerator TerrainGeneratorRef;
    public PlayerSpeedController PlayerSpeedControllerRef;

    public void ChangeTexturesOfChunk(GameObject chunk)
    {
        Renderer[] v = chunk.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in v)
        {
            if (chunk.transform.rotation.eulerAngles.x == PlayerSpeedControllerRef.FlatSlope)
                r.sharedMaterial = NormalTexture;
            //Add more here.
        }
    }
}
