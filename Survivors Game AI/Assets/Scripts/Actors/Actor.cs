using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private StatsSO statSheet; 

    private int currentHealth;

    void Start()
    {

    }

    void Update()
    {

    }

    public void subtractHealth(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            DestroyActor();
        }
    }

    public void addHealth(int heal)
    {
        if (currentHealth + heal > statSheet.health)
        {
            currentHealth = statSheet.health;
        }
        else
        {
            currentHealth += heal;
        }
    }

    public virtual void ResetActor()
    {

    }

    public void DestroyActor()
    {
        transform.parent.GetComponent<Factory>().DestroyItem(gameObject);
    }
}
