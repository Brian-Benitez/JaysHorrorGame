using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnglesOfTerrain : MonoBehaviour
{
    [SerializeField]
    public List<float> RandomAnglesForTerrain;

    public int AmountOfChilds = 2;

    public void PickRandomAngleForParent(GameObject go)
    {
        int index = Random.Range(0, RandomAnglesForTerrain.Count);
        float newAngle = RandomAnglesForTerrain[index];
        go.transform.eulerAngles = new Vector3(newAngle, 0);
        Debug.Log("New angle is " + newAngle);
        //now make the childs of the obj change angles
        PickRandomAngleForChilds(go);
    }

    private void PickRandomAngleForChilds(GameObject gameObject)
    {

        for (int i = 0; i < AmountOfChilds; i++)
        {
            int index = Random.Range(0, RandomAnglesForTerrain.Count);
            float newAngle = RandomAnglesForTerrain[index];
            gameObject.transform.GetChild(i).eulerAngles = new Vector3(newAngle, 0);
            Debug.Log("New anglem for child is " + newAngle);
        }
    }
}
