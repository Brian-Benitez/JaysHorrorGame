using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerSpeedController : MonoBehaviour
{
    [Header("Speeds")]
    public int VineSurfaceFastSpeed;
    public int RoughSurfaceNormalSpeed;
    public int SmoothSurfaceSlowestSpeed;
    //Add more here..

    [Header("Angles of Slopes")]
    public float FlatSlope = 0f;
    public float EasySlope = 30f;
    public float IntermidSlope = 60f;
    public float HardSlope = 90f;

    [Header("Scripts")]
    public TerrainGenerator Generator;

    
    public void OnTriggerEnter(Collider other)
    {
        CheckGroundTagAndSet(other);
        //Generator.GenerateNewTerrain(); This works but I need to work on this more later!
    }
    /// <summary>
    /// Check when the player hits the ground, what layer the player is running on, then changes the speed of the player.
    /// </summary>
    /// <param name="groundCollider"></param>
    private void CheckGroundTagAndSet(Collider groundCollider)
    {
        CheckTerrainAngles();
        Debug.Log("checkl this");

        if (groundCollider.gameObject.CompareTag("Ground"))
            GetComponent<PlayerController>().Speed = VineSurfaceFastSpeed;
        else if (groundCollider.gameObject.CompareTag("SlowGround"))
            GetComponent<PlayerController>().Speed = SmoothSurfaceSlowestSpeed;
        //^Trying this out, seeing if it will impact performance, if does, just going to ref the script instead of get component.
    }
    //I can do this a bit better below...
    private void CheckTerrainAngles()
    {
        Debug.Log("look " + Generator.Terrains[0].transform.rotation.eulerAngles.x);
        if (Generator.Terrains[0].transform.rotation.eulerAngles.x == FlatSlope)
            Debug.Log("Skibiibi");
        else if (Generator.Terrains[0].transform.rotation.eulerAngles.x >= EasySlope && Generator.Terrains[0].transform.rotation.eulerAngles.x < IntermidSlope)
            Debug.Log("HAHAHA");
        else if (Generator.Terrains[0].transform.rotation.eulerAngles.x >= IntermidSlope && Generator.Terrains[0].transform.rotation.eulerAngles.x < HardSlope)
            Debug.Log("offf");
        else if (Generator.Terrains[0].transform.rotation.eulerAngles.x >= HardSlope)
            Debug.Log("oh no");
    }
}
