using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mario : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private Rigidbody body;

    [SerializeField]
    private InputActionReference move;
    [SerializeField]
    private InputActionReference interact;

    private DialogueTrigger dialogueTrigger;
    private Vector2 moveInput;

    private void OnEnable()
    {
        move.action.performed += Move;
        move.action.canceled += Move;
        move.action.Enable();
        interact.action.started += Interact;
        interact.action.Enable();
    }

    private void OnDisable()
    {
        move.action.performed -= Move;
        move.action.canceled -= Move;
        move.action.Disable();
        interact.action.started -= Interact;
        interact.action.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Interact(InputAction.CallbackContext _)
    {
        if (dialogueTrigger)
        {
            dialogueTrigger.Interact();
        }
    }

    void Update()
    {
        body.linearVelocity = new Vector3(moveInput.x, 0.0f, moveInput.y) * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        DialogueTrigger trigger = other.GetComponent<DialogueTrigger>();
        if (trigger)
        {
            dialogueTrigger = trigger;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (dialogueTrigger != other.GetComponent<DialogueTrigger>())
        {
            return;
        }

        if (dialogueTrigger)
        {
            dialogueTrigger.Exit();
            dialogueTrigger = null;
        }
    }
}
