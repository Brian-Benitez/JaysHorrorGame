using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading;

public class PlayerCam : MonoBehaviour
{
    [Header("Values")]
    public float sensX;
    public float sensY;
    public float RoateCamSpeed;
    [Header("Transforms")]
    public Transform PlayerBody;

    [Header("Scripts")]
    public PlayerController PController;
    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 10f);
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        PlayerBody.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //NOTE: ^This works BUT, it rotates the WHOLE player... so maybe just rotate something else or figure it out..
        //PlayerBody.Rotate(Vector3.up * mouseX);

        
        //Player input
        if(Input.GetKey(KeyCode.C))
            PlayerRotateCamera();

        if(Input.GetKeyUp(KeyCode.C))
        {
            this.transform.DORotate(new Vector3(0f, 0f, 0f), RoateCamSpeed, RotateMode.Fast);
            PController.Speed = 12f;
        }
            


        
    }
    /// <summary>
    /// This function rotates the camera when the player presses the button.
    /// </summary>
    private void PlayerRotateCamera()
    {
        yRotation = Mathf.Clamp(yRotation, 0f, 0f);

        PController.Speed = 0f;
        
        this.transform.DORotate(new Vector3(20f, -180f, 0f), RoateCamSpeed, RotateMode.Fast);//The vectors are the angle of when the player turns theyre head.
        Debug.Log("I work");
    }
}
