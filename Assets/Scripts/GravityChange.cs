using UnityEngine;


public class GravityChange : MonoBehaviour
{
    public float gravityStrength = 20f;
    public float rotationSpeed = 10f;
    public float jumpForce = 8f;
    public Vector3 GravityDir => gravityDir;
    public Quaternion GravityTilt => gravityTilt;
    private CharacterController _cc;
    private Camera playerCamera;
    private Vector3 gravityDir = Vector3.down;
    private float gravityVelocity = 0f;

    private Quaternion gravityTilt = Quaternion.identity;
    private Quaternion targetTilt  = Quaternion.identity;

    void Awake()
    {
        _cc = GetComponent<CharacterController>();

        playerCamera = GetComponentInChildren<Camera>();
        if (playerCamera == null)
            playerCamera = Camera.main;

        gravityDir  = Vector3.down;
        gravityTilt = Quaternion.identity;
        targetTilt  = Quaternion.identity;
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
        if (!Input.GetKeyDown(KeyCode.E))
            return;

    Vector3 cameraDirection = playerCamera.transform.forward;

    Vector3[] cardinals = {
        Vector3.forward, Vector3.back,
        Vector3.left,    Vector3.right,
        Vector3.up,      Vector3.down
    };

    Vector3 best = Vector3.forward;
    float bestDot = -Mathf.Infinity;
    foreach (Vector3 dir in cardinals)
    {
        float dot = Vector3.Dot(cameraDirection, dir);
        if (dot > bestDot)
        {
            bestDot = dot;
            best = dir;
        }
    }

    SetGravity(best);
    }

    void SetGravity(Vector3 direction)
    {
        gravityDir = direction.normalized;
        gravityVelocity = 0f;

        Vector3 newUp = -gravityDir;
        Vector3 forward = Vector3.ProjectOnPlane(Vector3.forward, newUp).normalized;
        if (forward == Vector3.zero)
            forward = Vector3.ProjectOnPlane(Vector3.right, newUp).normalized;

        targetTilt = Quaternion.LookRotation(forward, newUp);
    }

    void SmoothRotateToGravity()
    {
        gravityTilt = Quaternion.Slerp(gravityTilt, targetTilt, rotationSpeed * Time.deltaTime);
    }

    void ApplyGravity()
    {
        bool isGrounded = IsGroundedCustom();

        if (isGrounded && gravityVelocity > 0f)
            gravityVelocity = 0f;

        if (isGrounded && Input.GetButtonDown("Jump"))
            gravityVelocity = -jumpForce;

        if (!isGrounded)
            gravityVelocity += gravityStrength * Time.deltaTime;

        _cc.Move(gravityDir * gravityVelocity * Time.deltaTime);
    }
    bool IsGroundedCustom()
    {
        float checkDistance = _cc.skinWidth + 0.15f;

        return Physics.Raycast(
            transform.position,
            gravityDir,
            out _,
            (_cc.height * 0.5f) + checkDistance,
            ~LayerMask.GetMask("Player")
        );
    }
}