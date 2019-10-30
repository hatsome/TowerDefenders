using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private MoveController moveController;

    [SerializeField]
    private float speed = 2f;

    private bool isMoveLeft;
    private bool isMoveRight;
    private bool isMoveUp;
    private bool isMoveDown;

    private Rigidbody rb;

    void Start()
    {
        moveController = GetComponent<MoveController>();
        moveController.MoveLeft += OnMoveLeft;
        moveController.MoveRight += OnMoveRight;
        moveController.MoveUp += OnMoveUp;
        moveController.MoveDown += OnMoveDown;

        rb = GetComponent<Rigidbody>();
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

    private void FixedUpdate()
    {
        if (isMoveLeft)
        {
            rb.MovePosition(transform.position + new Vector3(-speed, 0f, 0f) * Time.fixedDeltaTime);
            isMoveLeft = false;
        }

        if (isMoveRight)
        {
            rb.MovePosition(transform.position + new Vector3(speed, 0f, 0f) * Time.fixedDeltaTime);
            isMoveRight = false;
        }

        if (isMoveUp)
        {
            rb.MovePosition(transform.position + new Vector3(0f, 0f, speed) * Time.fixedDeltaTime);
            isMoveUp = false;
        }

        if (isMoveDown)
        {
            rb.MovePosition(transform.position + new Vector3(0f, 0f, -speed) * Time.fixedDeltaTime);
            isMoveDown = false;
        }
    }


    private void OnDestroy()
    {
        moveController.MoveLeft -= OnMoveLeft;
        moveController.MoveRight -= OnMoveRight;
        moveController.MoveUp -= OnMoveLeft;
        moveController.MoveDown -= OnMoveRight;
    }
}
