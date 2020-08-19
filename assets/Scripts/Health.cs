public class Health
{
    private readonly float _maxHealth;
    public float CurrentHealth;

    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
        CurrentHealth = _maxHealth;
    }
}