using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private new Camera camera;
    [SerializeField] private float speed = .5f;
    [SerializeField] private float sprint = 2.5f;
    
    [SerializeField] private string level;
    private float xRotation;
    private float yRotation;

    private GravityChange _gravityChange;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _gravityChange = GetComponent<GravityChange>();
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        respawn();
        backtoMenu();
    }

    private void respawn()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(level);
        }
    }

     private void backtoMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void HandleMouseLook()
    {
        var mouseY = Input.GetAxis("Mouse Y");
        var mouseX = Input.GetAxis("Mouse X");

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        xRotation += mouseX;

        Quaternion tilt = _gravityChange.GravityTilt;
        transform.rotation = tilt * Quaternion.Euler(0f, xRotation, 0f);

        camera.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    }

    void HandleMovement()
    {
        var vertInput = Input.GetAxis("Vertical");
        var horInput  = Input.GetAxis("Horizontal");

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isSprinting ? speed * sprint : speed;

        // Project camera directions onto the current gravity surface plane
        Vector3 gravityUp  = -_gravityChange.GravityDir;
        Vector3 camForward = Vector3.ProjectOnPlane(camera.transform.forward, gravityUp).normalized;
        Vector3 camRight   = Vector3.ProjectOnPlane(camera.transform.right,   gravityUp).normalized;

        Vector3 moveDir = (camForward * vertInput + camRight * horInput) * currentSpeed * Time.deltaTime;

        characterController.Move(moveDir);
    }
}