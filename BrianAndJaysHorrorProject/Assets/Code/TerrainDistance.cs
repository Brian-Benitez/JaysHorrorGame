using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDistance : MonoBehaviour
{
    public bool IsHalfWayThere = false;

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
            IsHalfWayThere = true;
        IsHalfWayThere = false;
    }

}
