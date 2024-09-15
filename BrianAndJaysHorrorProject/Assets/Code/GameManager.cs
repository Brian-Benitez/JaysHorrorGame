using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Transforms")]
    public List<GameObject> TerrainChunks;

    [Header("Numbers")]
    public int AmountOfChildsInTerrains = 3;
    public int MaxAmountOfChunks;
    public int MaxAmountOfChunksToDelete;
    public int AmountOfChunkToPlace;//Make sure these are both and the same^
    public int TerrainIndex;
    public float SpaceZ = 2.0f;

    [Header("Strings for tags")]
    [SerializeField]
    public List<string> TerrainTagNames = new List<string>();
    [Header("Scrpits")]
    public ChangeTerrainTextures ChangeTerrainTexturesRef;
    public RandomAnglesOfTerrain RandomAnglesOfTerrainRef;

    /// <summary>
    /// Instantiate a new terrain chunk, add it to the list of terrains, then move it to posistion. 
    /// </summary>
    public void GenerateNewTerrain()//delete chunks within a radius....
    {
        Debug.Log("called");
        if (TerrainChunks.Count < MaxAmountOfChunks)
        {
            for (int i = 0; i < AmountOfChunkToPlace; i++)
            {
                GameObject NewTerrain = Instantiate<GameObject>(TerrainChunks[0]);//change this into a prefab
                TerrainChunks.Add(NewTerrain);
                NewTerrain.transform.position = TerrainChunks[TerrainIndex].transform.position + TerrainChunks[TerrainIndex].transform.forward * SpaceZ;
                RandomAnglesOfTerrainRef.PickRandomAngleForParent(NewTerrain);
                ChangeTagsOnChildTerrains(NewTerrain);
                ChangeTerrainTexturesRef.ChangeTexturesOfParentChunk(NewTerrain);
                Debug.Log("spawn new terrain");
                TerrainIndex++;
            }
        }
        else
            Debug.Log("do nothing, max count hit.");
        
    }

   /// <summary>
   /// Deletes old chunks that the player already pass through...
   /// </summary>
    private void DeleteOldChunks()// Look into this again and see how it works..
    {
        if(TerrainChunks.Count >= MaxAmountOfChunks)
        {
            for(int i = 0; i < MaxAmountOfChunksToDelete; i++)
            {
                Debug.Log("Deleting chunks of terrain");
                TerrainChunks[i].gameObject.SetActive(false);
                TerrainChunks.Remove(TerrainChunks[i]);
                Destroy(TerrainChunks[i]);
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
