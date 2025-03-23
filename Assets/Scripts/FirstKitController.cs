using UnityEngine;

public class FirstKitController : MonoBehaviour
{
    [SerializeField] private int firstKitValue;
    [SerializeField] private Health curentHealth;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Health>(out var health))
        {
            if(!curentHealth.IsHealthy) 
            {
                health.Healing(firstKitValue);
                Destroy(gameObject);
            }
        }
    }
}
