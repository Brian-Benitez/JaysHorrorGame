using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour//I ALREADY NEED TO CHANGE THE NAME OF THIS CLASS....
{
    [Header("Transforms")]
    public List<GameObject> TerrainChunks;

    [Header("Numbers")]
    public int AmountOfChildsInTerrains = 3;
    public int MaxAmountOfChunks;

    [Header("Strings for tags")]
    [SerializeField]
    public List<string> TerrainTagNames = new List<string>();

    /// <summary>
    /// Instantiate a new terrain chunk, add it to the list of terrains, then move it to posistion. 
    /// </summary>
    public void GenerateNewTerrain(Transform SpawnTerrainPoint)
    {
        for (int i = 0; i < TerrainChunks.Count; i++)
        {
            GameObject NewTerrain = Instantiate<GameObject>(TerrainChunks[0]);
            TerrainChunks.Add(NewTerrain);// need to also delete it later when im not on the platform.
            TerrainChunks[i].transform.position = SpawnTerrainPoint.transform.position;// need to make this go through the list of chunks
            ChangeTagsOnChildTerrains(NewTerrain);
            Debug.Log("spawn new terrain");
            return;//check if this works
        }
    }

   /// <summary>
   /// Deletes old chunks that the player already pass through...
   /// </summary>
    private void DeleteOldChunks()// Look into this again and see how it works..
    {
        if(TerrainChunks.Count > MaxAmountOfChunks)
        {
            for(int i = 0; i < MaxAmountOfChunks; i++)
            {
                Debug.Log("Deleting chunks of terrain");
                TerrainChunks[i].gameObject.SetActive(false);
                TerrainChunks.Remove(TerrainChunks[i]);
                Destroy(TerrainChunks[i]);//this is kinda expensive but we will see...
            }
        }
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
