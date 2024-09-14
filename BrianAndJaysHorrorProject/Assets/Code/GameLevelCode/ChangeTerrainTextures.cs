using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
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
    public GameManager GameManagerRef;
    public PlayerSpeedController PlayerSpeedControllerRef;

    public void ChangeTexturesOfParentChunk(GameObject chunk)
    {
        Renderer r = chunk.GetComponent<Renderer>();

        if (chunk.transform.CompareTag("Ground"))
            r.material = NormalTexture;
        else if (chunk.transform.CompareTag("SlowGround"))
            r.material = SlowTexture;

        ChangeChildsTextures(chunk);
    }

    private void ChangeChildsTextures(GameObject child)//clean this when we know it works..
    {
        Renderer[] v = child.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < AmountOfChilds; i++)
        {
            if (child.transform.GetChild(i).CompareTag("Ground"))
            {
                Debug.Log("this needs ground texture");
                Debug.Log("Name " + child.transform.GetChild(i).name);
                v[i + 1].material = NormalTexture;//added a +1 to the i index because the renderer also takes the parents renderer
            }

            else if (child.transform.GetChild(i).CompareTag("SlowGround"))
            {
                Debug.Log("use slow ground");
                Debug.Log("Name " + child.transform.GetChild(i).name);
                v[i + 1].material = SlowTexture;
            }

            Debug.Log("how many runs " + i);
        }
    }
}
