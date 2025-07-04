using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerControls;
    public float moveSpeed = 5f;
    public Camera cam;

    private void Awake()
    {
        playerControls = new PlayerController();
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
        Vector3 forward = cam.transform.forward;
        
        forward.y = 0f;
        Vector3 right = cam.transform.right;
        Debug.Log(right);
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        Vector3 movement = new Vector3(move.x*forward.x, 0, move.y * right.x) * moveSpeed * Time.fixedDeltaTime;

        transform.position = transform.position + movement;
    }


}
