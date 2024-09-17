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

    public float MaxRaycastDistance = 2f;
    public LayerMask Mask;



    private void FixedUpdate()
    {
        SlopeCheck();
    }

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
        if (groundCollider.gameObject.CompareTag("Ground"))
            GetComponent<PlayerController>().Speed = VineSurfaceFastSpeed;
        else if (groundCollider.gameObject.CompareTag("SlowGround"))
            GetComponent<PlayerController>().Speed = SmoothSurfaceSlowestSpeed;
        //^Trying this out, seeing if it will impact performance, if does, just going to ref the script instead of get component.
    }
   
    private void SlopeCheck()
    {
        RaycastHit hit;
       Vector3 FloorMax = new Vector3(0,0);
        if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.down), out hit, MaxRaycastDistance, Mask))
        {
            Debug.Log("ooga");
            Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector3.down), Color.red);
            Debug.Log(Vector3.Angle(hit.normal, Vector3.up) + " look");
        }
    }
}
