using UnityEngine;
using UnityEngine.Events;

public class EnemyWithGunAnimationController : MonoBehaviour
{
    [SerializeField] private UnityEvent enemyIsDead;
    private Animator animator;
    private EnemyWithGunNavigationController controller;
    private Health health;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<EnemyWithGunNavigationController>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        WalkAndIdleAnimations();
    }

    private void WalkAndIdleAnimations()
    {
        if (controller.IsMoving)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    public void DeathAnimation()
    {
        if (!health.IsAlive)
        {
            animator.SetTrigger("IsDead");
            enemyIsDead?.Invoke();
            Destroy(gameObject, 2f);
        }
    }
}
