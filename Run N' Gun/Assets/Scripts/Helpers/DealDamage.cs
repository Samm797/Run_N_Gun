using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Using TryGetComponent instead of GetComponent
        // If the Collider2D has an IDamagable object on it, it will make an IDamagable named damagable
        other.TryGetComponent<IDamagable>(out IDamagable damagable);

        // If (damagable != null) { }
        damagable?.Damage();
    }
}
