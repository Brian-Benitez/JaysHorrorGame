using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour//I ALREADY NEED TO CHANGE THE NAME OF THIS CLASS....
{
    [Header("Transforms")]
    public List<GameObject> TerrainChunks;

    [Header("Numbers")]
    public int AmountOfChildsInTerrains = 3;

    [Header("Space between terrains")]
    [SerializeField]
    private float SpaceZ = 2.0f;

    [Header("Strings for tags")]
    [SerializeField]
    public List<string> TerrainTagNames = new List<string>();

    /// <summary>
    /// 
    /// Instantiate a new terrain chunk, add it to the list of terrains, then move it to posistion. 
    /// </summary>
    public void GenerateNewTerrain()
    {
        GameObject SecondTerrain = Instantiate<GameObject>(TerrainChunks[0]);
        TerrainChunks.Add(SecondTerrain);
        SecondTerrain.transform.position = TerrainChunks[0].transform.position + TerrainChunks[0].transform.forward * SpaceZ;
        ChangeTagsOnChildTerrains(SecondTerrain);
        Debug.Log("spawn new terrain");
    }
    /// <summary>
    /// Change the tags of the childs of the terrain so the player can have a diffrent buff or debuff when climbing.
    /// </summary>
    /// <param name="NewTerrain"></param>
    private void ChangeTagsOnChildTerrains(GameObject NewTerrain)
    {
        int index = Random.Range(0, TerrainTagNames.Count);
        NewTerrain.transform.gameObject.tag = TerrainTagNames[index];
        //Then change the child of the main objects tags...
        for (int i = 0; i < AmountOfChildsInTerrains - 1; i++)
        {
            int newIndex = Random.Range(0, TerrainTagNames.Count);
            NewTerrain.transform.GetChild(i).gameObject.tag = TerrainTagNames[newIndex];
            Debug.Log("name " + TerrainChunks[1].transform.GetChild(i).name);
        }
    }
}
