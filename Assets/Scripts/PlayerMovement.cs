using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float horizontalSpeed = 2f;
    [SerializeField] float verticalSpeed = 2f;

    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue, yValue, zValue);

        float horizontalRotate = Input.GetAxis("Mouse X") * Time.deltaTime * horizontalSpeed;
        // Negative to flip down and up looking
        float verticalRotate = -Input.GetAxis("Mouse Y") * Time.deltaTime * horizontalSpeed;

        transform.Rotate(verticalRotate, horizontalRotate, 0);
    }
}
