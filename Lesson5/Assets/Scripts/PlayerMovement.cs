using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour    
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private LayerMask _groundMask;
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _gravity = -9.8f;
    [SerializeField]
    private float _jumpHeight = 3f;
    [SerializeField]
    private float _groundDistance = 0.04f;

    Vector3 velocity;

    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * _speed * Time.deltaTime);
        velocity.y = _gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(_jumpHeight - 2f * _gravity);
        }

        if (Input.GetKey("c"))
        {
            _controller.height = 1f;
        }
        else
        {
            _controller.height = 2f;
        }

        if (Input.GetKey("left shift"))
        {
            _speed = 20f;
        }
        else
        {
            _speed = 10f;
        }
    }
}
