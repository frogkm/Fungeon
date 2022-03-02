using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShotGunController : WeaponController {

    [SerializeField] private int spreadCount;
    [SerializeField] private int spreadDensity;
    System.Random r = new System.Random();

    private void shootAt(float inc) {
        GameObject e = Instantiate(bullet) as GameObject;
        e.transform.position = bulletSpawnPoint.position;
        Rigidbody2D bulletRb = e.GetComponent<Rigidbody2D>();
        float angle = transform.eulerAngles.z;
        angle += inc;
        angle = (angle * (float)(Math.PI)) / 180;
        float bulletYVel = bulletSpeed * (float)Math.Sin(angle);
        float bulletXVel = bulletSpeed * (float)Math.Cos(angle);
        bulletRb.velocity = new Vector2(bulletXVel, bulletYVel);
        e.transform.rotation = transform.rotation;
    }

    protected override void shoot() {
        for (int i = 0; i < spreadCount; i++){
            shootAt((float)r.Next(-spreadDensity / 2, spreadDensity / 2));
        }

    }


}
