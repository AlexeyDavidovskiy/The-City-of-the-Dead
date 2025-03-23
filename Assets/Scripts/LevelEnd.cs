using UnityEngine;
using UnityEngine.Events;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private UnityEvent levelEnd;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Helicopter") || other.TryGetComponent<Rigidbody>(out var rb))
        {
            levelEnd?.Invoke();
        }
    }
}
