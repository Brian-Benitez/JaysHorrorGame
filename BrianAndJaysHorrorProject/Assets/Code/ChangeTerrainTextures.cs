using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeTerrainTextures : MonoBehaviour
{
    [Header("Textures")]
    public Material SlowTexture, FastTexture, NormalTexture;
    [Header("Amount of childs in chunk")]
    [Header("Make sure if you change how much childs are in a chunk to change it here!")]
    public int AmountOfChilds = 2;
    
    [Header("Scripts")]
    public TerrainGenerator TerrainGeneratorRef;
    public PlayerSpeedController PlayerSpeedControllerRef;

    public void ChangeTexturesOfChunk(GameObject chunk)
    {
        Renderer[] v = chunk.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < AmountOfChilds; i++)
        {
            if(chunk.transform.GetChild(i).CompareTag("Ground"))
                v[i].sharedMaterial = NormalTexture;
            else if(chunk.transform.GetChild(i).CompareTag("SlowGround"))
                v[i].sharedMaterial = SlowTexture;
            //Add more here...
        }
    }
}
