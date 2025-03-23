using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Settings")]
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private LayerMask groundMask;
    private Rigidbody rb;
    private GroundCheck groundCheck;

    public bool isMoving => rb.velocity.x != 0;

    public float VerticalSpeed => rb.velocity.y;

    public bool isRotated => rb.rotation.y < 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
    }

    public void Move(float direction)
    {
        if (Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);
        }
    }

    public void Rotation(float direction)
    {
        Vector2 movementDirection = new Vector2(direction, 0);

        if (movementDirection != Vector2.zero)
        {
            transform.forward = movementDirection;
        }
    }

    public void Jump()
    {
        if (groundCheck.Grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction) * moveSpeed, rb.velocity.y);
    }
}
