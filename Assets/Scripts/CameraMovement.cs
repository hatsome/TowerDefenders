using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float panspeed = 20f;
    [SerializeField]
    private float angleRight = 30f;
    [SerializeField]
    private float scrollSpeed = 20f;

    private CameraMovementController moveController;

    private bool isMoveLeft;
    private bool isMoveRight;
    private bool isMoveUp;
    private bool isMoveDown;

    private bool isRotateLeft;
    private bool isRotateRight;

    private float valueZoomCamera;

    private Transform cameraPosTracker;

    void Start()
    {
        moveController = GetComponent<CameraMovementController>();
        moveController.MoveCameraLeft += OnMoveLeft;
        moveController.MoveCameraRight += OnMoveRight;
        moveController.MoveCameraUp += OnMoveUp;
        moveController.MoveCameraDown += OnMoveDown;
        
        moveController.RotateCameraLeft += OnRotateLeft;
        moveController.RotateCameraRight += OnRotateRight;

        moveController.ZoomCamera += OnZoomCamera;

        cameraPosTracker = GetComponentInParent<PositionTracker>().transform;
    }

    private void OnMoveLeft()
    {
        isMoveLeft = true;
    }

    private void OnMoveRight()
    {
        isMoveRight = true;
    }

    private void OnMoveUp()
    {
        isMoveUp = true;
    }

    private void OnMoveDown()
    {
        isMoveDown = true;
    }

    private void OnRotateLeft()
    {
        isRotateLeft = true;
    }

    private void OnRotateRight()
    {
        isRotateRight = true;
    }

    private void OnZoomCamera(float scroll)
    {
        valueZoomCamera = scroll;
    }

    private void LateUpdate()       //Move CameraPosition
    {
        Vector3 direction = Vector3.zero;
        float angleRightTime = 0f;
        Vector3 rotation = cameraPosTracker.rotation.eulerAngles;

        if (isMoveLeft)
        {
            direction.z = panspeed * Time.deltaTime;
            isMoveLeft = false;
        }

        if (isMoveRight)
        {
            direction.z = -panspeed * Time.deltaTime;
            isMoveRight = false;
        }
        
        if (isMoveUp)
        {
            direction.x = panspeed * Time.deltaTime;
            isMoveUp = false;
        }

        if (isMoveDown)
        {
            direction.x = -panspeed * Time.deltaTime;
            isMoveDown = false;
        }

        if (isRotateLeft)
        {
            angleRightTime -= angleRight * Time.deltaTime;
            isRotateLeft = false;
        }

        if (isRotateRight)
        {
            angleRightTime += angleRight * Time.deltaTime;
            isRotateRight = false;
        }

        if(valueZoomCamera != 0)
        {
            direction.y -= valueZoomCamera * scrollSpeed * 50f * Time.deltaTime;
            valueZoomCamera = 0;
        }
        
        cameraPosTracker.Rotate(Vector3.up, angleRightTime);
        cameraPosTracker.Translate(direction, cameraPosTracker);
    }


    private void OnDestroy()
    {
        moveController.MoveCameraLeft -= OnMoveLeft;
        moveController.MoveCameraRight -= OnMoveRight;
        moveController.MoveCameraUp -= OnMoveUp;
        moveController.MoveCameraDown -= OnMoveDown;

        moveController.RotateCameraLeft -= OnRotateLeft;
        moveController.RotateCameraRight -= OnRotateRight;

        moveController.ZoomCamera -= OnZoomCamera;
    }
}
