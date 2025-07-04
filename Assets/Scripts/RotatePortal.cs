using UnityEngine;

public class RotatePortal : MonoBehaviour
{
    private RectTransform imageRectTransform;
    public float rotationSpeed;
    void Start()
    {
        imageRectTransform = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 angles = imageRectTransform.eulerAngles; 
        angles.z = angles.z - rotationSpeed * Time.deltaTime; // + rotationSpeed for right button
        imageRectTransform.eulerAngles = angles;
    }
}
