using UnityEngine;

public interface HitObject
{
    void Hit(HitInfo hitInfo);
}
public abstract class Enemy : MonoBehaviour, HitObject
{
    protected float health;
    protected float damage;
    public abstract void Hit(HitInfo hitInfo);

    public abstract void OnCollisionEnter2D(Collision2D collision);
}
