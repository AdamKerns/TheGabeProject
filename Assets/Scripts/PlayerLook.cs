using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private PlayerController lookControl;
    [SerializeField]
    private Camera cam;
    private float X;
    private float Y;
    public float Sensitivity;

    void Awake()
    {
        lookControl = new PlayerController();
        Vector3 euler = transform.rotation.eulerAngles;
        X = euler.x;
        Y = euler.y + 90;
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
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        Vector2 look = lookControl.Player.Look.ReadValue<Vector2>();
        float lookX = look.x;
        float lookY = look.y;
        Debug.Log(look);
        const float Min_X = 0f;
        const float Max_X = 360f;
        const float Min_Y = -90f;
        const float Max_Y = 90f;

        X += lookX * (Sensitivity * Time.deltaTime);
        if (X < Min_X) X += Max_X;
        else if (X > Max_X) X -= Max_X;
        Y -= lookY * (Sensitivity * Time.deltaTime);
        if (Y <= Min_Y) Y = Min_Y;
        else if (Y >= Max_Y) Y = Max_Y;

        cam.transform.rotation = Quaternion.Euler(Y, X, 0f);
        if (lookControl.UI.Escape.ReadValue<float>() == 1) Cursor.lockState = CursorLockMode.None;
    }
}
