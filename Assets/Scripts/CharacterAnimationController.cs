using UnityEngine;
using UnityEngine.Events;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private UnityEvent isDead;
    private PlayerMovement playerMovement;
    private Animator animator;
    private Health health;
    private PlayerInput playerInput;
    private GroundCheck groundCheck;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        playerInput = GetComponent<PlayerInput>();
        groundCheck = GetComponent<GroundCheck>();
    }

    private void Update()
    {
        RunningAnimation();
        JumpingAnimation();
    }

    private void RunningAnimation()
    {
        if (playerMovement.isMoving)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void JumpingAnimation()
    {
        animator.SetBool("IsGrounded", groundCheck.Grounded);
        animator.SetFloat("VerticalSpeed", playerMovement.VerticalSpeed);
    }

    public void RunningPerShooting()
    {
        if (!playerMovement.isMoving)
        {
            animator.SetTrigger("IsShooting");
        }
        else if (playerMovement.isMoving)
        {
            animator.SetTrigger("IsShootingAndRunning");
        }
    }

    public void DeathAnimation()
    {
        if (!health.IsAlive)
        {
            animator.SetTrigger("IsDead");
            isDead?.Invoke();
            playerInput.enabled = false;
        }
    }
}
