using UnityEngine;

public interface HitObject
{
    void Hit(HitInfo hitInfo);
}
public abstract class Enemy : MonoBehaviour, HitObject
{
    float health;
    float damage;
    public abstract void Hit(HitInfo hitInfo);
}
