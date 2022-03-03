using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class WeaponController : MonoBehaviour {

    [SerializeField] protected float timeBetweenShots;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected GameObject bullet; //Bullet type/size is unique to weapon sometimes and have effects
    [SerializeField] protected Transform bulletSpawnPoint; //Ease of adjustment for fire point
    //[SerializeField] protected Transform holdPivotPoint; //Ease of adjustment for pivot point (gun handle)
    [SerializeField] protected bool automatic; //Can I hold trigger to continue shooting?
    [SerializeField] protected int damage; //Base damage for this weapon

    protected float nextShotTime; //How long untill next bullet can be shot?
    protected bool canShoot; //Can a bullet be fired right now?
    protected SpriteRenderer spriteRenderer;
    protected Vector3 pivotPoint;


    protected void Start(){
      canShoot = true;
      spriteRenderer = GetComponent<SpriteRenderer>();
      //pivotPoint = holdPivotPoint.position;
      bullet.GetComponent<BulletController>().gunDamage = damage;
    }


    // Update is called once per frame
    protected void Update()
    {
      if (transform.parent.parent.localEulerAngles.z < 270 && transform.parent.parent.localEulerAngles.z > 90) {
        transform.localScale = new Vector2(transform.localScale.x, -Mathf.Abs(transform.localScale.y));
      }
      else {
        transform.localScale = new Vector2(transform.localScale.x, Mathf.Abs(transform.localScale.y));
      }

      if (!canShoot){
        if (Time.time > nextShotTime){
          canShoot = true;
        }
      }
    }

    void FixedUpdate() {

    }

    protected virtual void shoot() {
        GameObject e = Instantiate(bullet) as GameObject;
        //e.GetComponent<BulletController>().setGunDamage(damage);  //I don't love this
        e.transform.position = bulletSpawnPoint.position;
        Rigidbody2D bulletRb = e.GetComponent<Rigidbody2D>();
        float angle = transform.eulerAngles.z;
        angle = (angle * (float)(Math.PI)) / 180;

        float bulletYVel = bulletSpeed * (float)Math.Sin(angle);
        float bulletXVel = bulletSpeed * (float)Math.Cos(angle);
        bulletRb.velocity = new Vector2(bulletXVel, bulletYVel);
        e.transform.rotation = transform.rotation;
    }

    public void tryShoot() {
        if (canShoot) {
            shoot();
            canShoot = false;
            nextShotTime = Time.time + timeBetweenShots;
        }
    }

    public bool isAutomatic(){
        return automatic;
    }
}
