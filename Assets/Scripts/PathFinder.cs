using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PathFinder : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigidBody;
    System.Random r = new System.Random();
    private bool goingSomewhere;
    private Vector3 destination;
    private Queue backlog;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        goingSomewhere = false;
        backlog = new Queue();

        enqueuePlace(new Vector3(transform.position.x - 3f, transform.position.y - 3f, 0));
        enqueuePlace(new Vector3(transform.position.x, transform.position.y, 0));
        enqueuePlace(new Vector3(transform.position.x + 4f, transform.position.y - 3f, 0));
        enqueuePlace(new Vector3(transform.position.x - 4f, transform.position.y + 3f, 0));
    }

    void Update() {
      if (goingSomewhere) {
          adjustMovement();
          checkArrived();
      }
    }

    void FixedUpdate() {

    }

    private void checkArrived() {
        if (inRadius(destination, 0.25f)) {
            Debug.Log("MADE IT");
            //transform.position = destination;
            rigidBody.velocity = new Vector3(0, 0, 0);
            if (backlog.Count > 0) {
                nextPlace();
            }
            else {
                goingSomewhere = false;
            }
        }
    }

    private void enqueuePlace(Vector3 destination) {
        backlog.Enqueue(destination);
        if (!goingSomewhere) {
            nextPlace();
            goingSomewhere = true;
        }
    }

    private void nextPlace() {
        destination = (Vector3)backlog.Dequeue();
    }

    private void goPlace (Vector3 destination) {
        backlog.Clear();
        this.destination = destination;
        goingSomewhere = true;
    }

    private void adjustMovement() {
      //Debug.Log("Adjusting movement");
      Vector3 direction = destination - transform.position;


      //double angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      //float x = (float)Math.Cos(angle) * moveSpeed;
      //float y = (float)Math.Sin(angle) * moveSpeed;
      rigidBody.velocity = direction.normalized * moveSpeed;
      //rigidBody.velocity = new Vector3(x, y, 0);
      /*
      if(Mathf.Abs(direction.magnitude) < (new Vector3(x, y, 0)).magnitude * Time.deltaTime) {
        transform.position = destination;
      }
      else {
        rigidBody.velocity = new Vector3(x, y, 0);
      }
      */


    }

    private float getRandAngle(){
        return (Mathf.Deg2Rad * r.Next(0, 360));
    }

    public bool inRadius(Vector3 position, float radius) {
        float dis = Vector3.Distance(position, transform.position);
        return (radius >= dis);
    }


}
