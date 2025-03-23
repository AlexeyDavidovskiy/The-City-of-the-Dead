using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private AudioController audioEffects;
    [SerializeField] private ParticleSystem shotLight;
    private PlayerMovement playerMovement;
    private Ammo ammo;
    private Shooter shooter;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        ammo = GetComponent<Ammo>();
        shooter = GetComponent<Shooter>();
    }
     
    public void StartShooting() 
    {
        StartCoroutine(TimerForShooting(shooter));
    }

    public void Shoot()
    {
        if (ammo.MagazineIsNotEmpty)
        {
            var direction = playerMovement.isRotated ? Vector2.left : Vector2.right;

            Bullet bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            bullet.Initialization(direction, fireSpeed);

            shotLight.Play();

            ammo.Shooting();
            audioEffects.ShotSound();
        }
        else
        {
            audioEffects.EmptyFireSound();
        }
    }

    private IEnumerator TimerForShooting(Shooter shooter) 
    {
        yield return new WaitForSeconds(0.2f);
        shooter.Shoot();
    }
}
