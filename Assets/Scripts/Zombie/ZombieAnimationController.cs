using UnityEngine;
using UnityEngine.Events;

public class ZombieAnimationController : MonoBehaviour
{
    [SerializeField] private UnityEvent enemyIsDead;
    private Animator animator;
    private ZombieNavigationController navigationController;
    private Health health;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navigationController = GetComponent<ZombieNavigationController>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        WalkAndIdleAnimations();
    }

    private void WalkAndIdleAnimations()
    {
        if (navigationController.isWalking)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    public void DeathAnimation() 
    {
        if(!health.IsAlive) 
        {
            animator.SetTrigger("IsDead");
            enemyIsDead?.Invoke();
            Destroy(gameObject, 1.5f);
        }
    }

    public void AttackAnimation() 
    {
        animator.SetBool("IsAttacking", true);
    }

    public void CancelAttackAnimation() 
    {
        animator.SetBool("IsAttacking", false);
    }
}
