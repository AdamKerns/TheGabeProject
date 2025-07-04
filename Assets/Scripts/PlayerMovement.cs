using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerControls;
    private Rigidbody rb;
    private Camera camera;
    public float moveSpeed = 5f;

    private void Awake()
    {
        playerControls = new PlayerController();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void FixedUpdate()
    {
        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();
        
        Vector3 forward = camera.transform.forward;
        forward.y = 0f;
        Vector3 right = camera.transform.right;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = new Vector3(move.x * forward.x, 0, move.y * right.y) * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(transform.position + movement);
    }


}
