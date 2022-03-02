using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class BulletController : MonoBehaviour {
  [SerializeField] private float speed;  //bullet speed
  [SerializeField] private int damage;

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "PlayerBullet" || other.gameObject.tag == "EnemyBullet"){

    }
    else if (this.gameObject.tag == "PlayerBullet" && other.gameObject.tag == "Enemy"){
      EnemyController controller = other.GetComponent<EnemyController>();
      controller.setHealth(controller.getHealth() - damage);
      Destroy(this.gameObject, 0.05f);
    }
    else if (this.gameObject.tag == "EnemyBullet" && other.gameObject.tag == "Player"){
      PlayerController controller = other.GetComponent<PlayerController>();
      controller.setHealth(controller.getHealth() - damage);
      Destroy(this.gameObject, 0.05f);
    }
    else{
      Destroy(this.gameObject, 0.05f);
    }
  }

  public float getSpeed(){
    return speed;
  }

}
*/
