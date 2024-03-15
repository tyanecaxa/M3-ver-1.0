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
        CharacterController();
    }
    private void CharacterController()
    {
        _CharacterController = GetComponent<CharacterController>();

    }

    void Update()
    {
        JumpUpdate();
        MoveUpdate();
    }

    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _CharacterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }
    private void MoveUpdate()
    {
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
        MoveFixed();
        FallFixed();
        JumpFixed();
    }

    private void MoveFixed()
    {
        _CharacterController.Move(_moveVector * Speed *Time.fixedDeltaTime);
    }
    private void FallFixed()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
    }
    private void JumpFixed()
    {
        _CharacterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_CharacterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
