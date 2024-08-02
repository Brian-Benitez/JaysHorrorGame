using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [Header("Transforms")]
    public List<GameObject> Terrains;

    public float SpaceZ = 2.0f;
    public bool IsPressed = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R) && !IsPressed)
            GenerateNewTerrain();
        IsPressed = false;
    }

    public void GenerateNewTerrain()
    {
        IsPressed = true;   
        GameObject SecondTerrain = Instantiate<GameObject>(Terrains[0]);
        SecondTerrain.transform.position = Terrains[0].transform.position + Terrains[0].transform.forward * SpaceZ;
        Debug.Log("spawn new terrain");
    }
}
