using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerControls;
    public float moveSpeed = 5f;
    public Transform camTransform;

    private void Awake()
    {
        playerControls = new PlayerController();
    }

    void Start()
    {
        camTransform ??= Camera.main.transform;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        camRelativeMovement();
    }

    void camRelativeMovement()
    { 
        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();
        float vert = move.y / moveSpeed;
        float horiz = move.x / moveSpeed;

        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;
        forward.y = 0;
        right.y = 0;

        Vector3 forwardRelative = vert * forward;
        Vector3 rightRelative = horiz * right;

        Vector3 camRelative = forwardRelative + rightRelative;
        this.transform.Translate(camRelative, Space.World);
    }


}
