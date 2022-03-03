using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(LivingThing))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PathFinder))]
public class EnemyController : MonoBehaviour {

    [SerializeField] private float sightRadius;
    [SerializeField] private GameObject target;

    private LivingThing livingThing;
    private Rigidbody2D rigidBody;
    private PathFinder pathFinder;

    private State state;
    private bool shouldLookAt;

    enum State {
      Wandering,
      Attacking,
      Retreating
    }

    // Start is called before the first frame update
    void Start() {
      livingThing = GetComponent<LivingThing>();
      rigidBody = GetComponent<Rigidbody2D>();
      pathFinder = GetComponent<PathFinder>();
      shouldLookAt = false;
      state = State.Wandering;
    }

    void Update() {
      shouldLookAt = targetInRadius();
    }

    public void gotHit(int damage) {
      livingThing.setHealth(livingThing.getHealth() - damage);

    }

    void FixedUpdate() {
      if (shouldLookAt) {
        livingThing.lookAt(target.GetComponent<Transform>().position);
      }
    }

    private bool targetInRadius() {
      return pathFinder.inRadius(target.GetComponent<Transform>().position, sightRadius);
    }
}
