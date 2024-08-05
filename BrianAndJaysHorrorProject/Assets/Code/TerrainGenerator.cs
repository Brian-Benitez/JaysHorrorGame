using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour//I ALREADY NEED TO CHANGE THE NAME OF THIS CLASS....
{
    [Header("Transforms")]
    public List<GameObject> Terrains;
    public int AmountOfChildsInTerrains = 3;

    [Header("Space between terrains")]
    [SerializeField]
    private float SpaceZ = 2.0f;

    [Header("Booleans")]
    [SerializeField]
    private bool IsPressed = false;

    [Header("Strings for tags")]
    [SerializeField]
    public List<string> TerrainTagNames = new List<string>();

    private void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.R) && !IsPressed)
            GenerateNewTerrain();
        IsPressed = false;
        */
    }
    /// <summary>
    /// This adds a new terrain to the terrain list and removes the old one.
    /// </summary>
    /// <param name="NewGameObject"></param>
    private void AddingNewTerrainToList(GameObject NewGameObject)
    {
        Terrains.Remove(Terrains[0]);
        Terrains.Add(NewGameObject);
    }

    private void GenerateNewTerrain()
    {
        //IsPressed = true;   
        GameObject SecondTerrain = Instantiate<GameObject>(Terrains[1]);
        SecondTerrain.transform.position = Terrains[0].transform.position + Terrains[0].transform.forward * SpaceZ;
        ChangeTagsOnChildTerrains(SecondTerrain);
        Debug.Log("spawn new terrain");
    }

    private void ChangeTagsOnChildTerrains(GameObject NewTerrain)
    {
        int index = Random.Range(0, TerrainTagNames.Count);
        NewTerrain.transform.gameObject.tag = TerrainTagNames[index];
        //Then change the child of the main objects tags...
        for (int i = 0; i < AmountOfChildsInTerrains - 1; i++)
        {
            int newIndex = Random.Range(0, TerrainTagNames.Count);
            NewTerrain.transform.GetChild(i).gameObject.tag = TerrainTagNames[newIndex];
            Debug.Log("name " + Terrains[1].transform.GetChild(i).name);
        }
    }
}
