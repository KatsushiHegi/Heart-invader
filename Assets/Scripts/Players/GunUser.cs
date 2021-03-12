using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUser : MonoBehaviour
{
    public Gun _gun { get; private set; }

    PlayerInputHandller playerInputHandller;
    void Start()
    {
        playerInputHandller = GetComponent<PlayerInputHandller>();
        _gun = new HandGun();
        StartCoroutine(Shooting());
    }
    IEnumerator Shooting()
    {
        while (true)
        {
            yield return _gun.HandleShootInputs(
                playerInputHandller.GetFireInputDown(),
                playerInputHandller.GetFireInputHeld(),
                playerInputHandller.GetFireInputReleased(),
                transform);
        }
    }
}
