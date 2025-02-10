using UnityEngine;
public enum PlayerState
{
    Idle,
    Running
}

public class MainCharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;
    public Animator animator;

    private CharacterController controller;
    [SerializeField]private PlayerState currentState = PlayerState.Idle;
    private float pitch = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor for better control
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Change state based on key input
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            ChangeState(PlayerState.Running);
        }
        else
        {
            ChangeState(PlayerState.Idle);
        }
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate Player Horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate Camera Vertically
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void ChangeState(PlayerState newState)
    {
        if (currentState == newState) return; // Prevent redundant state changes

        currentState = newState;

        switch (currentState)
        {
            case PlayerState.Idle:
                animator.SetTrigger("Idle");
                break;

            case PlayerState.Running:
                animator.SetTrigger("Run");
                break;
        }
    }
}
