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
       mousePosition = Input.mousePosition;
       mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

       //transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x));
       //Transform pos = transform.TransformDirection(Vector3.forward * 3);
       //transform.LookAt(new Transform(Input.mousePosition));
       Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward );
       transform.rotation = rot;
       transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z);

    }
}
