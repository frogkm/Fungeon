using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingThing : MonoBehaviour {

    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float rotateSpeed = 10f;

    private int health;

    void Update(){


    }

    void FixedUpdate(){
        checkDeath();
    }

    void Start(){
        health = maxHealth;
    }


    public void lookAt(Vector3 position) {
      Utils.lookAt(transform, position, rotateSpeed);
    }

    public void checkDeath(){
        if (health <= 0){
            die();
        }
    }

    public void die(){
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    public void setHealth(int health){
        this.health = health;
    }
    public int getHealth(){
        return health;
    }


}
