using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed  = 8f;
    public float rotationSmoothTime = 0.1f;

    private float   rotationVelocity;
    private Rigidbody rb;
    private Animator  animator;
    private Transform cam;

    // Shared between Update and FixedUpdate
    private Vector3 moveDir;
    private bool    isMoving;

    void Start()
    {
        rb       = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        cam      = Camera.main.transform;

        rb.freezeRotation = true;
        rb.interpolation  = RigidbodyInterpolation.Interpolate;
    }

    // ── Input + Animation → always runs every rendered frame ──────────
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = new Vector3(h, 0f, v).normalized;

        isMoving = inputDir.magnitude >= 0.1f;

        // FIX 2 & 3: SetBool every frame, outside the if block
        animator.SetBool("isWalking", isMoving);

        if (isMoving)
        {
            // Camera-relative target angle
            float targetAngle =
                Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg
                + cam.eulerAngles.y;

            // Smooth rotation
            float angle = Mathf.SmoothDampAngle(
                transform.eulerAngles.y,
                targetAngle,
                ref rotationVelocity,
                rotationSmoothTime
            );
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Store move direction for FixedUpdate
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }

    // ── Physics → only moves the body, never touches animation ────────
    void FixedUpdate()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float speed    = isRunning ? runSpeed : moveSpeed;

        // FIX 1: Set XZ velocity, KEEP Y so gravity still works
        Vector3 vel = moveDir.normalized * (isMoving ? speed : 0f);
        vel.y = rb.velocity.y;   // ← this one line stops the flying
        rb.velocity = vel;
    }
}