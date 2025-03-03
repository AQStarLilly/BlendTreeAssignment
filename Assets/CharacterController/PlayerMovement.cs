using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playerRigidbody;
    public Vector2 moveVector = Vector2.zero;

    [SerializeField]
    private float moveSpeed = 3.0f;

    [SerializeField]
    private float sprintMultiplier = 2f;

    private float currentSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        Actions.MoveEvent += UpdateMoveVector;
        Actions.SprintEvent += UpdateSprintState;

        currentSpeed = moveSpeed;
    }

    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void UpdateMoveVector(Vector2 InputVector)
    {
        moveVector = InputVector;
    }

    private void UpdateSprintState(bool isSprinting)
    {
        currentSpeed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;
    }

    void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    void HandlePlayerMovement()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + moveVector * currentSpeed * Time.fixedDeltaTime);
    }

    void OnDisable()
    {
        Actions.MoveEvent -= UpdateMoveVector;
        Actions.SprintEvent -= UpdateSprintState;
    }
}
