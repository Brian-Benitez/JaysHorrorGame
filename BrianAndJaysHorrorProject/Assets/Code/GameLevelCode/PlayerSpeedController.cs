using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerSpeedController : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField]
    public int VineSurfaceFastSpeed;
    [SerializeField]
    public int RoughSurfaceNormalSpeed;
    [SerializeField]
    public int SmoothSurfaceSlowestSpeed;
    //Add more here..

    [Header("Angles of Slopes")]
    [SerializeField]
    public float FlatSlope = 0f;
    [SerializeField]
    public float EasySlope = 30f;
    [SerializeField]
    public float IntermidSlope = 60f;
    [SerializeField]
    public float HardSlope = 90f;

    [Header("Scripts")]
    public GameManager Generator;

    
    public void OnTriggerEnter(Collider other)
    {
        CheckGroundTagAndSet(other);
    }
    /// <summary>
    /// Check when the player hits the ground, what layer the player is running on, then changes the speed of the player.
    /// </summary>
    /// <param name="groundCollider"></param>
    private void CheckGroundTagAndSet(Collider groundCollider)
    {
        CheckTerrainAngles();

        if (groundCollider.gameObject.CompareTag("Ground"))
            GetComponent<PlayerController>().Speed = VineSurfaceFastSpeed;
        else if (groundCollider.gameObject.CompareTag("SlowGround"))
            GetComponent<PlayerController>().Speed = SmoothSurfaceSlowestSpeed;
        //^Trying this out, seeing if it will impact performance, if does, just going to ref the script instead of get component.
    }
    /// <summary>
    /// This checks on what the angle of the plane is, and to change the players velocity
    /// </summary>
    private void CheckTerrainAngles()
    {
        Debug.Log("look " + Generator.TerrainChunks[0].transform.rotation.eulerAngles.x);
        if (Generator.TerrainChunks[0].transform.rotation.eulerAngles.x == FlatSlope)
            Debug.Log("Skibiibi");
        else if (Generator.TerrainChunks[0].transform.rotation.eulerAngles.x >= EasySlope && Generator.TerrainChunks[0].transform.rotation.eulerAngles.x < IntermidSlope)
            Debug.Log("HAHAHA");
        else if (Generator.TerrainChunks[0].transform.rotation.eulerAngles.x >= IntermidSlope && Generator.TerrainChunks[0].transform.rotation.eulerAngles.x < HardSlope)
            Debug.Log("offf");
        else if (Generator.TerrainChunks[0].transform.rotation.eulerAngles.x >= HardSlope)
            Debug.Log("oh no");
    }
}
