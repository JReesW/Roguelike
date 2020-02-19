using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Player,
    Enemy
}

public interface Weapon
{
    void Attack();
}

public abstract class Sword : MonoBehaviour, Weapon
{
    protected float attackSpeed;
    protected float damage;
    PolygonCollider2D baseCollider;

    int timer;
    bool col;

    public void Start()
    {
        GameObject x = Resources.Load("Prefabs/SwordCollider") as GameObject;
        baseCollider = x.GetComponent<PolygonCollider2D>();
        timer = 0;
    }

    public void Update()
    {
        if (col)
        {
            timer++;

            if (timer > (60 * attackSpeed))
            {
                timer = 0;
                col = false;

                PolygonCollider2D collider = gameObject.GetComponent<PolygonCollider2D>();

                Destroy(collider);
                Debug.Log("Collider no longer active!");
            }
        }
    }

    public void Attack()
    {
        Debug.Log(damage);
        PolygonCollider2D collider = gameObject.AddComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;
        collider = baseCollider;
        col = true;
        Debug.Log("Collider now active!");
     }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObject = collision.gameObject;

        HitInfo info = new HitInfo(damage, Team.Player);

        hitObject.GetComponent<HitObject>().Hit(info);
    }
}

public class HitInfo
{
    public float damage;
    public Team team;

    public HitInfo (float damage, Team team)
    {
        this.damage = damage;
        this.team = team;
    }
}