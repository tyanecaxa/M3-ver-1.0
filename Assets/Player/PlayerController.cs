using System.Collections;using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelocity = 0;
    private float gravity = 9.8f;

    private CharacterController _CharacterController;

    private void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _CharacterController.Move(Vector3.down * gravity * Time.fixedDeltaTime);
    }
}
