using UnityEngine;

public class BulletDamageDealler : MonoBehaviour
{
    [SerializeField] private int minDamageValue;
    [SerializeField] private int maxDamageValue;
    private int randomDamageValue;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            randomDamageValue = Random.Range(minDamageValue, maxDamageValue);
            health.TakeDamage(randomDamageValue);
        }

        Destroy(gameObject, 0.1f);
    }
}
