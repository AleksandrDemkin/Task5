using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _jumpSpeed;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jSpeed = 0.0f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (_controller.isGrounded)
        {
            _jSpeed = 0.0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jSpeed = _jumpSpeed;
            }
        }
        _jSpeed += _gravity * Time.deltaTime * 3.0f;

        Vector3 dir = new Vector3(h * _speed, _jSpeed*Time.deltaTime, v * _speed);
        _controller.Move(dir);

    }
}
