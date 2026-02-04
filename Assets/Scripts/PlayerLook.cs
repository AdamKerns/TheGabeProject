using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private PlayerController lookControl;
    [SerializeField] private Camera cam;
    private float pitch;
    private float yaw;
    public float Sensitivity = 75f;
    private bool firstLook = true;

    void Awake()
    {
        lookControl = new PlayerController();
        
        
        yaw = transform.eulerAngles.y;
        pitch = 0f;
    }

    void OnDisable()
    {
        lookControl.Disable();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        lookControl.Enable();

        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
        cam.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void LateUpdate()
    {
        Vector2 look = lookControl.Player.Look.ReadValue<Vector2>();

        if (firstLook)
        {
            if (look.sqrMagnitude > 0f)
            {
                firstLook = false;
            }
            return;
        }

        yaw += look.x * Sensitivity * Time.deltaTime;
        pitch -= look.y * Sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.rotation = Quaternion.Euler(0f,yaw,0f);
        cam.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        if (lookControl.UI.Escape.ReadValue<float>() == 1) Cursor.lockState = CursorLockMode.None;
    }
}
