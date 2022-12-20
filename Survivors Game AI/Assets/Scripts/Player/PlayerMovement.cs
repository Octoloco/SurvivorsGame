using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private StatsSO statSheet;
    private PlayerInputActions inputActions;

    private void OnEnable()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();

        inputActions.PlayerControls.Movement.performed += ctx => HandleMovementInput(ctx.ReadValue<Vector2>());
        inputActions.PlayerControls.Movement.canceled += ctx => HandleMovementInput(ctx.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        inputActions.PlayerControls.Movement.performed -= ctx => HandleMovementInput(ctx.ReadValue<Vector2>());
        inputActions.PlayerControls.Movement.canceled -= ctx => HandleMovementInput(ctx.ReadValue<Vector2>());
        inputActions.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        statSheet = Resources.Load<StatsSO>("ScriptableObjects/PlayerStatSheet");
    }

    private void HandleMovementInput(Vector2 input)
    {
        if (input.magnitude > 0)
        {
            rb.velocity = input * statSheet.movementSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}

