using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public float RoateCamSpeed;

    public Transform PlayerBody;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Changed Time.deltaTime to fixed to fix jidder of camera.
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 10f);
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        PlayerBody.Rotate(Vector3.up * mouseX);

        //Player input
        if(Input.GetKey(KeyCode.C))
            PlayerRotateCamera();
        if(Input.GetKeyUp(KeyCode.C))
            this.transform.DORotate(new Vector3(0f, 0f, 0f), RoateCamSpeed, RotateMode.Fast);

    }
    /// <summary>
    /// This function rotates the camera when the player presses the button.
    /// </summary>
    private void PlayerRotateCamera()
    {
        yRotation = Mathf.Clamp(yRotation, 0f, 0f);
        //The vectors are the angle of when the player turns theyre head.
        this.transform.DORotate(new Vector3(20f, -180f, 0f), RoateCamSpeed, RotateMode.Fast);
        Debug.Log("I work");
    }
}
