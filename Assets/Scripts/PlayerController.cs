using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Transform transform;
  public float speed;

    // Start is called before the first frame update
    void Start()
    {
      transform = GetComponent<Transform>();
      speed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.W)){
         transform.position = transform.position + new Vector3(0, speed, 0);
       }
       if (Input.GetKey(KeyCode.A)){
         transform.position = transform.position + new Vector3(-speed, 0, 0);
       }
       if (Input.GetKey(KeyCode.S)){
         transform.position = transform.position + new Vector3(0, -speed, 0);
       }
       if (Input.GetKey(KeyCode.D)){
         transform.position = transform.position + new Vector3(speed, 0, 0);
       }
    }
}
