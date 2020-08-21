using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour, IDamageable
{
    [SerializeField] private ShipAttributes shipAttributes;
    private Health _health;
    
    private void Start()
    {
        _health = new Health(shipAttributes.maxHealth);
    }

    private void Update()
    {
        if (_health.CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("PlayAgain");
    }

    public float GetHealth()
    {
        return _health.CurrentHealth;
    }

    public ShipAttributes GetAttributes()
    {
        return shipAttributes;
    }
    
    public void TakeDamage(float amount)
    {
        _health.CurrentHealth -= amount - shipAttributes.armor;
    }
}