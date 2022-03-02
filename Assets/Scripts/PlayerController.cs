using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LivingThing))]
[RequireComponent(typeof(WeaponHolder))]
public class PlayerController : MonoBehaviour {

    [SerializeField] private float movementSpeed;

    private Rigidbody2D rigidBody;
    private LivingThing livingThing;
    private WeaponHolder weaponHolder;

    private float xInput;
    private float yInput;
    private float leftMouseInput;
    private float leftShiftInput;
    private bool triggerDownAfterShot;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        livingThing = GetComponent<LivingThing>();
        weaponHolder = GetComponent<WeaponHolder>();
        triggerDownAfterShot = false;

    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        leftMouseInput = Input.GetAxisRaw("Fire1");
        leftShiftInput = Input.GetAxisRaw("Fire3");

        if (leftMouseInput != 1){
            triggerDownAfterShot = false;
        }
    }

    void FixedUpdate(){
        Vector2 direction = Utils.mousePos() - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //livingThing.lookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (leftMouseInput == 1 && (!triggerDownAfterShot || weaponHolder.isAutomatic())) {
            weaponHolder.tryShoot();
            triggerDownAfterShot = true;
        }
        rigidBody.velocity = new Vector2(xInput * movementSpeed, yInput * movementSpeed);
    }
}
