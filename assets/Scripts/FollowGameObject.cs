using System;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothing = 0.125f;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing);
        transform.position = smoothedPosition;
    }
}
