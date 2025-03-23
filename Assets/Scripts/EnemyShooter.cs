using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private AudioController audioEffects;
    [SerializeField] private float timeToShoot;
    [SerializeField] private float resTimeToShoot;
    [SerializeField] private ParticleSystem shotLight;
    private Ammo ammo;
    private EnemyWithGunNavigationController controller;

    private void Awake()
    {
        ammo = GetComponent<Ammo>();
        controller = GetComponent<EnemyWithGunNavigationController>();
    }

    private void Update()
    {
        if (controller.CharacterDetected) 
        {
            timeToShoot -= Time.deltaTime;
            if (timeToShoot < 0)
            {
                Shoot();
                timeToShoot = resTimeToShoot;
            }
        }
    }

    private void Shoot() 
    {
        if (ammo.MagazineIsNotEmpty)
        {
            var direction = controller.IsRotated ? Vector2.left : Vector2.right;

            Bullet bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            bullet.Initialization(direction, fireSpeed);

            ammo.Shooting();
            shotLight.Play();
            audioEffects.ShotSound();
        }
        else
        {
            ammo.Reloding();
            audioEffects.ReloadingSound();
        }
    }
}
