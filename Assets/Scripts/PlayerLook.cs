using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private PlayerController lookControl;

    void Awake()
    {
        lookControl = new PlayerController();
    }

    void OnEnable()
    {
        lookControl.Enable();
    }

    void OnDisable()
    {
        lookControl.Disable();
    }
    void Start()
    {
        
    }

    void LateUpdate()
    { 
        Vector2 look = lookControl.Player.Look.ReadValue<Vector2>();
        float lookX = look.x;
        float lookY = look.y;
        Debug.Log(look);
    }
}
