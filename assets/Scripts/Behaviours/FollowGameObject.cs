using System;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    [SerializeField] private float smoothing = 1;
    [SerializeField] private Vector3 offset;

    private Transform _target;

    private void OnEnable()
    {
        EventManager.StartListening("PlayerSpawned", FindPlayer);
    }

    private void FindPlayer()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = _target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing);
        transform.position = smoothedPosition;
    }
}
