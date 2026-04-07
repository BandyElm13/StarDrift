using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private new Camera camera;
    [SerializeField] private float speed = .5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float sprint = 2.5f;
    private float xRotation;
    private float yRotation;
    private float verticalVelocity = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.LockState
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse x an y
        var mouseY = Input.GetAxis("Mouse Y");
        var mouseX = Input.GetAxis("Mouse X");
        // Adjust stored rotation
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        xRotation += mouseX;
        // Rotate based on stored rotation
        transform.rotation = Quaternion.Euler(new Vector3(0f, xRotation, 0f));
        camera.transform.rotation = Quaternion.Euler(new Vector3(yRotation,xRotation, 0f));

    //vertical and horizontal
        var vertInput = Input.GetAxis("Vertical");
        var horInput = Input.GetAxis("Horizontal");

    //sprinting
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isSprinting ? speed * sprint : speed;

        var fowardDir = transform.forward * vertInput * Time.deltaTime * currentSpeed;
        var sideDir = transform.right * horInput * Time.deltaTime * speed;


    // Jumping and gravity
        if (characterController.isGrounded)
        {
            verticalVelocity = -1f; // Small negative keeps grounded check stable
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += gravity  * Time.deltaTime;
        }
        var updir = transform.up * verticalVelocity * Time.deltaTime;

        var vector = fowardDir + sideDir + updir;

        //inistializes character movement
        characterController.Move(vector);

    }
}