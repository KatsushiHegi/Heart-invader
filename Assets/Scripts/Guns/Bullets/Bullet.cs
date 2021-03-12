using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet
{
    public float _damage { get; protected set; }
    public float _bulletSpeed { get; protected set; }
    public GameObject _bulletObject { get; protected set; }

    public Bullet(float damage, float bulletSpeed, GameObject bulletObject) 
    {
        _damage = damage;
        _bulletSpeed = bulletSpeed;
        _bulletObject = bulletObject;
    }
}

