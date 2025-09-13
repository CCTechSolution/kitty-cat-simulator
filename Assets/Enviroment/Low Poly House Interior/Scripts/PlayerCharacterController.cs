using UnityEngine;

public class PlayerCharacterController : MonoBehaviour {

    [Header("Movement & MouseLook")]
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float mouseSensitivity = 2f;


    private CharacterController characterController;
    private Camera playerCamera;
    private float cameraVerticalAngle;

    private float verticalVelocity;
    private float gravity = 40f;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        playerCamera = transform.Find("Camera").GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        HandleCharacterLook();
        HandleCharacterMovement();
    }

    public void HandleCharacterLook() {
        float lookX = Input.GetAxisRaw("Mouse X");
        float lookY = Input.GetAxisRaw("Mouse Y");

        transform.Rotate(new Vector3(0f, lookX * mouseSensitivity, 0f), Space.Self);
        cameraVerticalAngle -= lookY * mouseSensitivity;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);
        playerCamera.transform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
    }

    private void HandleCharacterMovement() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 characterVelocity = transform.right * moveX * moveSpeed + transform.forward * moveZ * moveSpeed;
        // Move Character Controller
        characterController.Move(characterVelocity * Time.deltaTime);

        if(characterController.isGrounded) {
            verticalVelocity = -gravity * Time.deltaTime * 100;
        }

        Vector3 moveVector = new Vector3(0,verticalVelocity,0);
        characterController.Move(moveVector * Time.deltaTime);
    }  
}