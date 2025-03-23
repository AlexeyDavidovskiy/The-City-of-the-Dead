using UnityEngine;

public class CollectAmmo : MonoBehaviour
{
    [SerializeField] int bulletsInPack;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Ammo>(out var ammo)) 
        {
            ammo.RefillingAmmo(bulletsInPack);
            Destroy(gameObject);
        }
    }
}
