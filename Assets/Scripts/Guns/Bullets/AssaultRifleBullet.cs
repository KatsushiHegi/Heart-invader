using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifleBullet : Bullet
{
    public AssaultRifleBullet()
        : base(1.5f, 1.2f, (GameObject)Resources.Load("Bullets/3dObjects/AssaultRifleBullet")) { }
}
