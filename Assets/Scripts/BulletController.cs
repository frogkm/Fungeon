using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
  public int damage;

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "PlayerBullet" || other.gameObject.tag == "EnemyBullet"){

    }
    else if (this.gameObject.tag == "PlayerBullet" && other.gameObject.tag == "Enemy"){
      EnemyController controller = other.GetComponent<EnemyController>();
      controller.setHealth(controller.getHealth() - damage);
      Destroy(this.gameObject, 0.05f);
    }
    else{
      Destroy(this.gameObject, 0.05f);
    }



  }

}
