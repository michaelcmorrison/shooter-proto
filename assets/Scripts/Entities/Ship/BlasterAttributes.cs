using UnityEngine;

[CreateAssetMenu(fileName = "Blaster Attributes", menuName = "Scriptable Objects/Blaster Attributes")]
public class BlasterAttributes : ScriptableObject
{
    public string description;
    public GameObject projectilePrefab;
    public float fireRate;
}