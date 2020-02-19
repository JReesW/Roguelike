using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nob : MonoBehaviour, HitObject
{
    public float speed;

    public Rigidbody2D rigidBody;
    Weapon weapon;
    public Vector2 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        weapon = gameObject.GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            weapon.Attack();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidBody.velocity = movement * speed;




        //Rotation
        Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 playerPos = Camera.main.WorldToViewportPoint(transform.position);

        float d = Vector2.Distance(mouse, playerPos);
        float dx = mouse.x - playerPos.x;
        float angle;

        if (mouse.y > playerPos.y)
        {
            angle = Mathf.Acos(dx / d) * Mathf.Rad2Deg;
        }
        else
        {
            angle = 360 - (Mathf.Acos(dx / d) * Mathf.Rad2Deg);
        }

        rigidBody.SetRotation(angle - 90);

    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void Hit(HitInfo hitInfo)
    {
        if (hitInfo.team != Team.Player)
        {
            Debug.Log("Player is hit");
        }
    }
}
