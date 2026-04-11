using UnityEngine;


public class GravityChange : MonoBehaviour
{
    public float gravityStrength = 20f;
    public float rotationSpeed = 10f;
    public float jumpForce = 8f;
    public Vector3 GravityDir => _gravityDir;
    public Quaternion GravityTilt => _gravityTilt;
    private CharacterController _cc;
    private Camera _playerCamera;
    private Vector3 _gravityDir = Vector3.down;
    private float _gravityVelocity = 0f;

    private Quaternion _gravityTilt = Quaternion.identity;
    private Quaternion _targetTilt  = Quaternion.identity;

    void Awake()
    {
        _cc = GetComponent<CharacterController>();

        _playerCamera = GetComponentInChildren<Camera>();
        if (_playerCamera == null)
            _playerCamera = Camera.main;

        _gravityDir  = Vector3.down;
        _gravityTilt = Quaternion.identity;
        _targetTilt  = Quaternion.identity;
    }

    void Update()
    {
        HandleGravityInput();
        SmoothRotateToGravity();
        ApplyGravity();
    }

    void HandleGravityInput()
    {
        if (!Input.GetMouseButton(1))
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetGravity(Vector3.left);// left
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SetGravity(Vector3.up); //up
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            SetGravity(Vector3.down);//down
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            SetGravity(Vector3.right); // right
        else if(Input.GetKeyDown(KeyCode.Q))
            SetGravity(Vector3.forward);
        else if(Input.GetKeyDown(KeyCode.E))
            SetGravity(Vector3.back);
    }

    void SetGravity(Vector3 direction)
    {
        _gravityDir = direction.normalized;
        _gravityVelocity = 0f;

        Vector3 newUp = -_gravityDir;
        Vector3 forward = Vector3.ProjectOnPlane(Vector3.forward, newUp).normalized;
        if (forward == Vector3.zero)
            forward = Vector3.ProjectOnPlane(Vector3.right, newUp).normalized;

        _targetTilt = Quaternion.LookRotation(forward, newUp);
    }

    void SmoothRotateToGravity()
    {
        _gravityTilt = Quaternion.Slerp(_gravityTilt, _targetTilt, rotationSpeed * Time.deltaTime);
    }

    void ApplyGravity()
    {
        bool isGrounded = IsGroundedCustom();

        if (isGrounded && _gravityVelocity > 0f)
            _gravityVelocity = 0f;

        if (isGrounded && Input.GetButtonDown("Jump"))
            _gravityVelocity = -jumpForce;

        if (!isGrounded)
            _gravityVelocity += gravityStrength * Time.deltaTime;

        _cc.Move(_gravityDir * _gravityVelocity * Time.deltaTime);
    }
    bool IsGroundedCustom()
    {
        float checkDistance = _cc.skinWidth + 0.15f;

        return Physics.Raycast(
            transform.position,
            _gravityDir,
            out _,
            (_cc.height * 0.5f) + checkDistance,
            ~LayerMask.GetMask("Player")
        );
    }
}