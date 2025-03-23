using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private UnityEvent healthChanged;
    public int currentHealth;

    public bool IsAlive => currentHealth > 0;
    public bool IsHealthy => currentHealth == maxHealth;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        if(currentHealth > 0) 
        {
            currentHealth -= damage;
            if(currentHealth < 0) 
            {
                currentHealth = 0;
            }
        }

        healthChanged?.Invoke();
    }

    public void Healing(int firstKit) 
    {
        if(currentHealth < maxHealth) 
        {
            currentHealth += firstKit;
            if(currentHealth > maxHealth) 
            {
                currentHealth = maxHealth;
            }
        }

        healthChanged?.Invoke();
    }
}
