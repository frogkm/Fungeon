using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{



  public static void lookAt(Transform transform, Vector3 position, float rotateSpeed) {
    Vector2 direction = position - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
  }

  public static Vector3 mousePos() {
    return Camera.main.ScreenToWorldPoint(Input.mousePosition);
  }

}
