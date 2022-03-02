using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {

    [SerializeField] private int numMaxWeapons = 10;
    [SerializeField] private GameObject startWeapon;
    [SerializeField] private Transform weaponHoldPoint; //Transform in entity hierarchy

    private GameObject weapon;
    private WeaponController weaponController;
    private GameObject[] weapons;
    private int weaponIdx;



    // Start is called before the first frame update
    void Start()
    {
        weaponIdx = 0;
        weapons = new GameObject[numMaxWeapons];
        weapons[0] = startWeapon;
        weapon = weapons[0];
        weapon = Instantiate(weapon); //Spawn weapon in world
        weapon.transform.position = weaponHoldPoint.position; //Move weapon into entity's hands
        weapon.transform.parent = weaponHoldPoint; //Set hold point as parent, so it moves with it
        weaponController = weapon.GetComponent<WeaponController>();

    }

    public void cycleWeapon(){
        weaponIdx ++;
        if (weaponIdx > weapons.Length - 1){
            weaponIdx = 0;
        }
        weapon = weapons[weaponIdx];
        weapon = Instantiate(weapon) as GameObject;
        weapon.transform.position = weaponHoldPoint.position;
        weapon.transform.parent = weaponHoldPoint;
        weaponController = weapon.GetComponent<WeaponController>();
    }

    /*
    public void switchWeapon(int idx) {
      weaponIdx = idx;
      weapon = weapons[weaponIdx];
      weapon = Instantiate(weapon) as GameObject;
      weapon.transform.position = weaponHoldPoint.position;
      weapon.transform.parent = weaponHoldPoint;
    }
    */

    public void tryShoot(){
        weaponController.tryShoot();
    }

    public bool isAutomatic(){
        return weaponController.isAutomatic();
    }


}
