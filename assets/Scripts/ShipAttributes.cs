using UnityEngine;

[CreateAssetMenu(fileName = "Ship Attributes", menuName = "Scriptable Objects/Ship Attributes")]
public class ShipAttributes : ScriptableObject
{
    public string description;
    public float maxHealth;
    public float armor;
}