using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnglesOfTerrain : MonoBehaviour
{
    [Header("Different types of angles")]
    [SerializeField]
    public List<float> RandomAnglesForTerrain;

    [Header("Numbers")]
    public int AmountOfChilds = 2;
    public float UnitToRise;

    [Header("Scripts")]
    public PlayerSpeedController PlayerSpeedControllerRef;

    /// <summary>
    /// Changes the parent objects angle.
    /// </summary>
    /// <param name="go"></param>
    public void PickRandomAngleForParent(GameObject go)//Instead of making it random, make presets of the one chunks position, THEN randomly pick one of them.
    {
        go.transform.eulerAngles = new Vector3 (0f, 0f, 0f);//Zero is flat!
        //now make the childs of the obj change angles
        PickRandomAngleForChilds(go);
    }
    /// <summary>
    /// Goes in a parent object and changes all the childs euler angles in a loop.
    /// </summary>
    /// <param name="gameObject"></param>
    private void PickRandomAngleForChilds(GameObject gameObject)
    {
        for (int i = 0; i < AmountOfChilds; i++)
        {
            float newAngle = 0f;
            int index = Random.Range(0, RandomAnglesForTerrain.Count);
            newAngle = RandomAnglesForTerrain[index];
            Vector3 rotateToAdd = new Vector3(newAngle, 0f, 0f);
            gameObject.transform.GetChild(i).Rotate(rotateToAdd);
            Debug.Log("New anglem for child is " + newAngle);
           
        }
    }
}
