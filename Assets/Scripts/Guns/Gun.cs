using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Gun
{
    public GameObject _bulletPref { get; } = (GameObject)Resources.Load("Bullets/Bullet");
    public int _capacity { get; protected set; }//装弾数
    public int _roundsNum { get; protected set; }//残弾数
    public bool _isAuto { get; private set; }//オートかセミオートか
    public ShootType _shootType;

    protected float _reloadSpeed;//リロード速度
    protected float _fireRate;//連射速度

    Bullet _bullet;
    Transform _bulletsPool = new GameObject("BulletsPool").transform;

    public Gun(Bullet bullet, int capacity, float reloadSpeed, float fireRate, ShootType shootType)
    {
        _bullet = bullet;
        _capacity = capacity;
        _roundsNum = _capacity;
        _reloadSpeed = reloadSpeed;
        _fireRate = fireRate;
        _shootType = shootType;
    }

    public IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(_reloadSpeed);
        _roundsNum = _capacity;
    }

    //一度に複数の弾を出す銃の場合、この関数をサブクラスでオーバーライドする
    public IEnumerator Shoot(Transform muzzle)
    {
        if (_roundsNum >= 1)
        {
            InstBullet(muzzle.position, muzzle.rotation);
            _roundsNum--;
            yield return new WaitForSeconds(_fireRate);
        }
        else
        {
            yield return Reload();
        }
    }

    protected void InstBullet(Vector3 pos, Quaternion rotation)
    {
        foreach (Transform t in _bulletsPool)
        {
            if (!t.gameObject.activeSelf)
            {
                t.SetPositionAndRotation(pos, rotation);
                t.gameObject.SetActive(true);
                return;
            }
        }
        var ins = UnityEngine.Object.Instantiate(_bulletPref, pos, rotation, _bulletsPool);
        BulletController bulletController = ins.GetComponent<BulletController>();
        bulletController.SetBullet(_bullet);
    }
    public IEnumerator HandleShootInputs(bool inputDown, bool inputHeld, bool inputUp, Transform muzzle)
    {
        switch (_shootType)
        {
            case ShootType.Manual:
                if (inputDown)
                {
                    yield return Shoot(muzzle);
                }
                break;
            case ShootType.Automatic:
                if (inputHeld)
                {
                    yield return Shoot(muzzle);
                }
                break;
        }
    }
}
public class HandGun : Gun
{
    public HandGun() : base(new HandGunBullet(), 10, 2f, 0.5f, ShootType.Manual) { }


}
public class AssaultRifle : Gun
{
    public AssaultRifle() : base(new AssaultRifleBullet(), 20, 3f, 0.1f, ShootType.Automatic) { }

}
public enum ShootType
{
    Manual,
    Automatic,
    Charge,
}