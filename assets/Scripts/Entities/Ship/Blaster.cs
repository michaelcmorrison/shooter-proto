using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] private BlasterAttributes blasterAttributes;
    private float _shotRefresh;

    private SoundManager _soundManager;

    private void Awake()
    {
        _soundManager = GetComponent<SoundManager>();
    }

    private void Update()
    {
        if (PlayerInput.Shoot && Time.time > _shotRefresh)
        {
            _shotRefresh = Time.time + blasterAttributes.fireRate;
            SpawnShot();
        }
    }

    private void SpawnShot()
    {
        var projectile = Instantiate(blasterAttributes.projectilePrefab, transform.position, transform.rotation);
        _soundManager.PlayClipAlternatingSources("Laser", true);
    }

    public BlasterAttributes GetAttributes()
    {
        return blasterAttributes;
    }
}
