using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BulletController : MonoBehaviour
{
  [SerializeField] private int bulletDamage;
  public int gunDamage;
  void Start()
  {

  }

  void Update()
  {

  }

  void OnTriggerEnter2D(Collider2D collider) {
    Debug.Log("HIT");
    if (collider.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
      Debug.Log("HEY");
      Destroy(this.gameObject);
      //bulletAnimator.SetBool("bulletIsDead", true);
    }
    else if(collider.gameObject.layer == LayerMask.NameToLayer("Enemy")){
      Destroy(this.gameObject);
      collider.gameObject.GetComponent<EnemyController>().gotHit(bulletDamage + gunDamage);
    }

  }
}
