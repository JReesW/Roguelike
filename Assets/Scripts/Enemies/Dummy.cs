﻿using UnityEngine;

public class Dummy : Enemy
{
    float damage;
    float health;

    // Start is called before the first frame update
    void Start()
    {
        health = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("I have deceased");
            Destroy(gameObject);
        }
    }

    public override void Hit(HitInfo hitInfo)
    {
        if (hitInfo.team != Team.Enemy)
        {
            Debug.Log($"Ow! I took {hitInfo.damage} damage");
            health -= hitInfo.damage;
        }
    }
}
