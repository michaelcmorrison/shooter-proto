using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform _transformToLookAt;

    private void Awake()
    {
        _transformToLookAt = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        LookAtTransform();
    }

    private void LookAtTransform()
    {
        var dir = transform.position - _transformToLookAt.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
