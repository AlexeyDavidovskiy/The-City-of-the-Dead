using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int maxMagazine;
    [SerializeField] private int maxReserve;
    [SerializeField] private UnityEvent ammoIsChanged;

    public int currentMagazine;
    public int currentReserve;
    private int bulletsHolder;
    private Ammo ammo;

    public bool MagazineIsNotEmpty => currentMagazine > 0;

    private void Awake()
    {
        ammo = GetComponent<Ammo>();
        currentMagazine = maxMagazine;
        currentReserve = maxReserve;
    }

    public void Shooting()
    {
        if (currentMagazine > 0)
        {
            currentMagazine -= 1;
        }

        ammoIsChanged?.Invoke();
    }

    public void StartReloading() 
    {
        StartCoroutine(TimerForReloading(ammo));
    } 

    public void Reloding()
    {
        if (currentReserve > 0 && currentReserve > maxMagazine && currentMagazine <= 0)
        {
            currentReserve -= maxMagazine;
            currentMagazine = maxMagazine;
        }
        else if (currentReserve > 0 && currentReserve > maxMagazine && currentMagazine > 0)
        {
            currentReserve += currentMagazine;
            currentReserve -= maxMagazine;
            currentMagazine = maxMagazine;
        }
        else if (currentReserve > 0 && currentReserve <= maxMagazine && currentMagazine <= 0)
        {
            bulletsHolder = currentReserve;
            currentReserve -= currentReserve;
            currentMagazine = bulletsHolder;
        }
        else if (currentReserve > 0 && currentReserve <= maxMagazine && currentMagazine > 0)
        {
            bulletsHolder = currentReserve + currentMagazine;
            currentReserve -= currentReserve;
            currentMagazine = bulletsHolder;
            if (currentMagazine > maxMagazine)
            {
                currentReserve = currentMagazine - maxMagazine;
                currentMagazine = maxMagazine;
            }
        }
        else if (currentReserve <= 0 && currentMagazine <= 0)
        {
            currentReserve = 0;
            currentMagazine = 0;
        }
        ammoIsChanged?.Invoke();
    }

    public void RefillingAmmo(int ammo)
    {
        currentReserve += ammo;
        ammoIsChanged?.Invoke();
    }

    private IEnumerator TimerForReloading(Ammo ammo) 
    {
        yield return new WaitForSeconds(2f);
        ammo.Reloding();
    }
}
