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

}
