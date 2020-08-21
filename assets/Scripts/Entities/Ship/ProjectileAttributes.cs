using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Attributes", menuName = "Scriptable Objects/Projectile Attributes")]
public class ProjectileAttributes : ScriptableObject
{
    public string description;
    public float projectileSpeed;
    public float damage;
}