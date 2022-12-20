using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrightShot : MonoBehaviour
{
    public int speed;
    public TestWeaponRanged weaponScript;
    public float destroyTime;

    private float destroyTimer = 0;

    private void Start()
    {
        destroyTimer = destroyTime;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (destroyTimer > 0)
        {
            destroyTimer -= Time.deltaTime;
        }
        else
        {
            destroyTimer = destroyTime;
            transform.parent.GetComponent<GenericFactoryScript>().DestroyObject(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //weaponScript.DealDamage(collision.GetComponent<Enemy>());
        }
    }
}
