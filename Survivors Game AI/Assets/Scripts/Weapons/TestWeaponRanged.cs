using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeaponRanged : Weapon
{
    [SerializeField] private GenericFactoryScript projectileFactory;

    override public void Activate()
    {
        GameObject temp;
        for (int i = 0; i < 4; i++)
        {
            temp = projectileFactory.SpawnItem(transform.parent.position, Quaternion.Euler(Vector3.forward * 90 * i));
            temp.GetComponent<StrightShot>().weaponScript = this;
        }
    }
}
