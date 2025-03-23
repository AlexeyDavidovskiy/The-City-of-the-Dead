using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private bool isGrounded = false;
    public bool Grounded => isGrounded;

    private void FixedUpdate()
    {
        CheckTheGround();
    }

    private void CheckTheGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
