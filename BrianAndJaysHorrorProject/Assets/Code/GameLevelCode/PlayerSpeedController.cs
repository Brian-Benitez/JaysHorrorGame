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
    [SerializeField]
    public int EasySurfaceSpeed;
    [SerializeField]
    public int IntermidSurfaceSpeed;
    //Add more here..

    [Header("Angles of Slopes")]
    [SerializeField]
    public float FlatSlope = 0f;
    public float EasySlope = 30f;
    [SerializeField]
    public float IntermidSlope = 60f;
    [SerializeField]
    public float HardSlope = 90f;

    [Header("Scripts")]
    public PlayerController PlayerControllerRef;

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
        if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.down), out hit, MaxRaycastDistance, Mask))
        {
            Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector3.down), Color.red);
            Debug.Log(Vector3.Angle(hit.normal, Vector3.up) + " look");
            ChangePlayersSpeed(Vector3.Angle(hit.normal, Vector3.up));
        }
    }

    private void ChangePlayersSpeed(float angle)
    {
        float roundAngleFloat = angle;
        roundAngleFloat = Mathf.Round(roundAngleFloat * 10.0f * 0.1f);

        if (roundAngleFloat == EasySlope)
            PlayerControllerRef.Speed = EasySurfaceSpeed;
        else if (roundAngleFloat == IntermidSlope)
            PlayerControllerRef.Speed = IntermidSurfaceSpeed;
        else if (roundAngleFloat == HardSlope)
            PlayerControllerRef.Speed = SmoothSurfaceSlowestSpeed;
        else if(roundAngleFloat == 0)
            PlayerControllerRef.Speed = VineSurfaceFastSpeed;

        Debug.Log("player speed is "+ PlayerControllerRef.Speed);
    }
}
