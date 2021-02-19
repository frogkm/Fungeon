using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

  public Rigidbody2D rb;
  public Transform transform;
  public float speed;
  public GameObject bullet;
  public float bulletSpeed;
  public float secondsPerShot;

  Vector3 mousePosition;
  float xVel;
  float yVel;
  float bulletYVel;
  float bulletXVel;
  float angle;
  float counter = 0f;

  // Start is called before the first frame update
  void Start()
  {
    transform = GetComponent<Transform>();
    rb = GetComponent<Rigidbody2D>();
  }

  //Rotates the transform's z plane to point it towards position
  void lookAt(Transform transform, Vector3 position){
    position = Camera.main.ScreenToWorldPoint(position);
    Quaternion rot = Quaternion.LookRotation(transform.position - position, Vector3.forward);
    transform.rotation = rot;
    transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
  }

  void setMovement(Rigidbody2D rb){
    xVel = 0;
    yVel = 0;

    if (Input.GetKey(KeyCode.W)){
      yVel += speed;
    }
    if (Input.GetKey(KeyCode.A)){
      xVel -= speed;
    }
    if (Input.GetKey(KeyCode.S)){
      yVel -= speed;
    }
    if (Input.GetKey(KeyCode.D)){
      xVel += speed;
    }

    rb.velocity = new Vector2(xVel, yVel);
  }

  void shootBullet(){
    GameObject e = Instantiate(bullet) as GameObject;
    Physics2D.IgnoreCollision(e.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    e.transform.position = transform.position;
    Rigidbody2D bulletRb = e.GetComponent<Rigidbody2D>();
    angle = transform.eulerAngles.z;

    angle = angle + 90;
    angle = (angle * (float)(Math.PI)) / 180;

    bulletYVel = bulletSpeed * (float)Math.Sin(angle);
    bulletXVel = bulletSpeed * (float)Math.Cos(angle);

    bulletRb.velocity = new Vector2(bulletXVel, bulletYVel);
  }

  // Update is called once per frame
  void Update()
  {
    //Debug.LogFormat("{0} trigger enter: {1}", this, this);
    counter += Time.deltaTime;
    setMovement(rb);
    lookAt(transform, Input.mousePosition);
    if (Input.GetKey(KeyCode.Mouse0) && counter >= secondsPerShot){
      counter = 0f;
      shootBullet();
    }

  }
}
