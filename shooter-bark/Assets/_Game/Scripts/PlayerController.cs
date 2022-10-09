using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private DynamicJoystick joystick;
    private float angle;

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
             angle = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
             transform.position += (transform.forward * (5f * Time.deltaTime));
        }
    }

}
