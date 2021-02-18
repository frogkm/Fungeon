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
  public Vector3 mousePosition;

  float xVel = 0;
  float yVel = 0;

  public GameObject bullet;
  public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
      transform = GetComponent<Transform>();
      rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
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

       // Rotation
       mousePosition = Input.mousePosition;
       mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
       Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
       transform.rotation = rot;
       transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z);


       if (Input.GetKey(KeyCode.Mouse0)){

         GameObject e = Instantiate(bullet) as GameObject;
         e.transform.position = transform.position;
         Rigidbody2D bulletRb = e.GetComponent<Rigidbody2D>();
         float angle = transform.eulerAngles.z;
         float xSign = 1;
         float ySign = 1;

         if (angle > -90){
           angle += 90;
         }
         if (angle < -90){
           angle += 450;
         }

         if (angle > 90 && angle < 180){
           xSign = -1;
         }
         else if (angle > 180 && angle < 270){
           xSign = -1;
           ySign = -1;
         }
         else if (angle > 270){
           ySign = -1;
         }


         //if(angle < 0){
        //    angle = 360 + angle;
         //}
      //   if (angle > 90){
    //       angle = 180 - angle;
      //   }
      //   else if (angle < -90){
      //     angle = 90 + angle;
      //   }

         float bulletYVel = ySign * bulletSpeed * (float)Math.Sin(angle);
         float bulletXVel = xSign * bulletSpeed * (float)Math.Cos(angle);

         bulletRb.velocity = new Vector2(bulletXVel, bulletYVel);

       }
       //Debug.Log();





    }
}
