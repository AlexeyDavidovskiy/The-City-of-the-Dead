using UnityEngine;

public class ZombieHordeDamageDealler : MonoBehaviour
{

    [SerializeField] private int damage;
    private ZombieHordeAnimationController controller;

    private void Awake()
    {
        controller = GetComponent<ZombieHordeAnimationController>();
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
