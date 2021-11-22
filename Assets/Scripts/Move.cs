using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{

    [SerializeField] Vector3 movementTransform;
    CharacterController characterController;
    PlayerInputController playerInputController;

    Vector2 readingValue;
    Vector3 movementValue;
    private bool onClick = false;
    [SerializeField] float speed=2;
    // Start is called before the first frame update
    void Awake()
    {
        readingValue = Vector2.zero;
        playerInputController = new PlayerInputController();
        characterController = GetComponent<CharacterController>();


        playerInputController.CharacterControls.Move.started += movementInput;
        playerInputController.CharacterControls.Move.performed += movementInput;
        playerInputController.CharacterControls.Move.canceled += movementInput;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClick = true;
        }
        if (Input.GetMouseButton(0))
        {
            characterController.Move(movementValue * Time.deltaTime * speed);
        }
        if (Input.GetMouseButtonUp(0))
        {
            onClick = false;
            readingValue = Vector2.zero;
        }

    }

    void movementInput(InputAction.CallbackContext context)
    {
        if (onClick)
        {
            readingValue = context.ReadValue<Vector2>();
            movementValue.x = readingValue.x/5f;
            movementValue.z = 0;
            Debug.Log(readingValue);
        }
        //isMoveActive = true;

    }

    private void OnEnable()
    {
        playerInputController.Enable();
    }
    private void OnDisable()
    {
        playerInputController.Disable();
    }
}
