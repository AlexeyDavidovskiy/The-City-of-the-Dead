using System;
using UnityEngine;
using UnityEngine.UI;

public class BulletCounter : MonoBehaviour
{
    [SerializeField] private Text magazinePannel;
    [SerializeField] private Text reservePannel;
    private Ammo ammo;

    private void Awake()
    {
        ammo = GetComponent<Ammo>();
    }

    private void Start()
    {
        ShowCurrentAmmo();
    }

    public void ShowCurrentAmmo() 
    {
        magazinePannel.text = Convert.ToString(ammo.currentMagazine);
        reservePannel.text = Convert.ToString(ammo.currentReserve);
    }
}
