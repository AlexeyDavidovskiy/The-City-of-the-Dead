using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody bullet;

    public void Initialization(Vector2 direction,float fireSpeed)
    {
        bullet.velocity = direction * fireSpeed;
    }
}
