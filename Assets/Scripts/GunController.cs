using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    
    public Transform weaponHold;
    public Gun StartingGun;
    Gun gun;

    void Start()
    {
        if(StartingGun != null)
        {
            EquipGun(StartingGun);
        }    
    }

    public void EquipGun(Gun gunToEquip) 
    {
        if(gun != null)
        {
            Destroy(gun.gameObject);
        }
        gun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation);
        gun.transform.parent = weaponHold;
    }

    public void Shoot()
    {
        if(gun != null)
        {
            gun.Fire();
        }
    }
}
