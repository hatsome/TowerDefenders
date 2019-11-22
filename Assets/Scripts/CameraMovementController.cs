using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField]
    private float panBorderThickness = 50f;

    public event Action MoveCameraLeft = delegate { };
    public event Action MoveCameraRight = delegate { };
    public event Action MoveCameraUp = delegate { };
    public event Action MoveCameraDown = delegate { };

    public event Action RotateCameraLeft = delegate { };
    public event Action RotateCameraRight = delegate { };

    public event Action<float> ZoomCamera = delegate { };

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveCameraLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveCameraRight();
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveCameraUp();
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveCameraDown();
        }

        if(Input.mousePosition.x <= panBorderThickness)
        {
            RotateCameraLeft();
        }

        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            RotateCameraRight();
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0.0f)
        {
            ZoomCamera(scroll);
        }
    }
}
