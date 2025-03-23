using UnityEngine;

public class ZombieDamageDealler : MonoBehaviour
{
    [SerializeField] private int damage;
    private ZombieAnimationController controller;

    private void Awake()
    {
        controller = GetComponent<ZombieAnimationController>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var health)) 
        {
            health.TakeDamage(damage);
            controller.AttackAnimation();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        controller.CancelAttackAnimation();
    }
}
