using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public int maxHealth;
  public int health;

    public void setHealth(int newHealth){
      health = newHealth;
    }

    public int getHealth(){
      return health;
    }

    void checkDeath(){
      if (health <= 0){
        Destroy(this.gameObject, 0f);
      }
    }

    // Start is called before the first frame update
    void Start()
    {
      health = maxHealth;


    }

    // Update is called once per frame
    void Update()
    {
      checkDeath();

    }
}
