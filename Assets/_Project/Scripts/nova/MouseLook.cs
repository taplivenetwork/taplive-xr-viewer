using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivity = 2f;
    float rotationX = 0f;
    float rotationY = 0f;

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}
