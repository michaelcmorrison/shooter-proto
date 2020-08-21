using UnityEngine;

public class Projectile : MonoBehaviour, IDamage
{
    [SerializeField] private ProjectileAttributes projectileAttributes;

    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rb.velocity = transform.up * projectileAttributes.projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            IDamageable damageable = other.gameObject.GetComponent<Enemy>();
            DealDamage(damageable);
        }
    }

    public void DealDamage(IDamageable damageable)
    {
        damageable.TakeDamage(projectileAttributes.damage);
    }
}