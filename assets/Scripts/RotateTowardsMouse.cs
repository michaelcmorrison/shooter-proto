using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        var dir = Input.mousePosition - _mainCamera.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
