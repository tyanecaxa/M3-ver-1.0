using System.Collections;using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelocity = 0;
    private float gravity = 9.8f;

    public float Speed;
    public float jumpForce;

    private CharacterController _CharacterController;
    private Vector3 _moveVector;

    void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _CharacterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

        //Move
        _moveVector = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input .GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
    }

    void FixedUpdate()
    {
        //move
        _CharacterController.Move(_moveVector * Speed *Time.fixedDeltaTime);

        //fall a jump
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _CharacterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_CharacterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
