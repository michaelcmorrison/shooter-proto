using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private MoverAttributes moverAttributes;
    
    private float _verticalForce;
    private float _horizontalForce;

    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _verticalForce = moverAttributes.moveSpeed * 100;
        _horizontalForce = moverAttributes.moveSpeed * 100;
    }

    public void Update()
    {
        Move();
    }

    public void Move()
    {
        var vertical = PlayerInput.Vertical * _verticalForce;
        var horizontal = PlayerInput.Horizontal * _horizontalForce;

        var force = new Vector2(horizontal, vertical) * Time.deltaTime;

        _body.AddForce(force);
    }

    public MoverAttributes GetAttributes()
    {
        return moverAttributes;
    }
}