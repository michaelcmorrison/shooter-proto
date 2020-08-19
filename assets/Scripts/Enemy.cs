using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float damage;
    private Health _health;

    private SoundManager _soundManager;

    private void Awake()
    {
        _soundManager = GetComponentInParent<SoundManager>();
    }

    private void Start()
    {
        _health = new Health(startingHealth);
    }

    private void Update()
    {
        if (Mathf.Approximately(_health.CurrentHealth, 0))
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        _health.CurrentHealth -= amount;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var ship = other.gameObject.GetComponent<Ship>();
            ship.TakeDamage(damage);
            Die();
        }
    }

    private void Die()
    {
        EventManager.InvokeEvent("EnemyDied");
        _soundManager.PlayClip("EnemyDied");
        Destroy(gameObject);
    }
}
