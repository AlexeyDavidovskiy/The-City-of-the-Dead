using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] private Text healthPannel;
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        ShowCurrentHealth();
    }

    public void ShowCurrentHealth() 
    {
        healthPannel.text = Convert.ToString(health.currentHealth);
    }
}
