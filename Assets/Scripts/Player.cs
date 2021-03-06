using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour
{

    public float moveSpeed = 5;
    PlayerController controller;
    GunController gunController;
    public event Action OnDeath;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
    }
    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 
                                        0, Input.GetAxis("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
    }
}
