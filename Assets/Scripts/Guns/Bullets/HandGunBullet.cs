using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunBullet : Bullet
{
    public HandGunBullet()
        : base(1f, 1f, (GameObject)Resources.Load("Bullets/3dObjects/HandGunBullet")) { }
}
