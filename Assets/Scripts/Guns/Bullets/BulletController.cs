using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Bullet _bullet;
    Rigidbody _rigidbody;
    public void SetBullet(Bullet bullet)
    {
        Init();
        _bullet = bullet;
        Instantiate(_bullet._bulletObject, transform);
    }
    void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }
    void Update()
    {
        BulletMovement();

    }

    public void BulletMovement()
    {
        _rigidbody.velocity += transform.rotation * Vector3.forward * _bullet._bulletSpeed;
    }
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        _rigidbody.velocity = Vector3.zero;
    }
}
