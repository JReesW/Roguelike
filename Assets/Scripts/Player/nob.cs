using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nob : MonoBehaviour
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 playerPos = Camera.main.WorldToViewportPoint(transform.position);

        float d = Vector2.Distance(mouse, playerPos);
        float dx = mouse.x - playerPos.x;
        float angle;

        if(mouse.y > playerPos.y)
        {
            angle = Mathf.Acos(dx / d) * Mathf.Rad2Deg;
        }
        else
        {
            angle = 360 - (Mathf.Acos(dx / d) * Mathf.Rad2Deg);
        }
        

        rigidBody.SetRotation(angle - 90);
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidBody.velocity = movement * speed;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void Hit()
    {
        Debug.Log("Player is hit");
    }
}
