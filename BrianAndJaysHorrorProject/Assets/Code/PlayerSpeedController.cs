using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedController : MonoBehaviour
{
    [Header("Speeds")]
    public int NormalSpeed;
    public int SlowedSpeed;
    //Add more here..

    public void OnTriggerEnter(Collider other)
    {
        CheckGroundTagAndSet(other);
        GetComponent<TerrainGenerator>().GenerateNewTerrain();
        Debug.Log("generate new terrain");
    }
    /// <summary>
    /// Check when the player hits the ground, what layer the player is running on, then changes the speed of the player.
    /// </summary>
    /// <param name="groundCollider"></param>
    private void CheckGroundTagAndSet(Collider groundCollider)
    {
        if (groundCollider.gameObject.CompareTag("Ground"))
            GetComponent<PlayerController>().Speed = NormalSpeed;
        else if (groundCollider.gameObject.CompareTag("SlowGround"))
            GetComponent<PlayerController>().Speed = SlowedSpeed;
        //^Trying this out, seeing if it will impact performance, if does, just going to ref the script instead of get component.
    }
}
