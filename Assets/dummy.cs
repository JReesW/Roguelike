using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int health;
    int damage;
    public abstract void Hit(float damageGet);
}

public class Dummy : Enemy
{
    int damage;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        damage = 2;
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

    public override void Hit(float damageGet)
    {
        Debug.Log($"Ow! I took {damageGet} damage");
    }
}
