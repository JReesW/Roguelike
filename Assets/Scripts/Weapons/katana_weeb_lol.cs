﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katana_weeb_lol : Sword
{

    public Transform playerTransform;
    public Transform WeaponTransform;
    public Vector3 offset;


    void Start()
    {
        //rigidBody = gameObject.GetComponent<Rigidbody2D>();
        //player = gameObject.GetComponent<Rigidbody2D>();
        base.Start();
        attackSpeed = .5f;
        damage = 5;
    }
    void FixedUpdate()
    {
        //WeaponTransform.position = playerTransform.position + offset;
    }
}
