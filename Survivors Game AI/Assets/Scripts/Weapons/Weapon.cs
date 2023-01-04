using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private int damage = 0;
    [SerializeField] private float activationRate = 0;
    [SerializeField] private bool phisicalDamage = true;
    [SerializeField] private int maxLevel = 0;
    [SerializeField] private int currentLevel = 0;

    private float activationTimer = 0;
    private bool isUsable = true;

    public int CurrentLevel { get { return currentLevel; } }

    private void Start()
    {
        activationTimer = activationRate;
    }

    private void Update()
    {
        if (isUsable)
        {
            if (activationTimer < 0)
            {
                Activate();
                activationTimer = activationRate;
            }
            else
            {
                activationTimer -= Time.deltaTime;
            }
                
        }
        else
        {
            activationTimer = activationRate;
        }
    }

    public void LevelUp()
    {
        if (currentLevel > maxLevel)
        {
            currentLevel++;
        }
    }

    public void ToggleUsable()
    {
        isUsable = !isUsable;
    }

    public virtual void Activate()
    {

    }

    public void DealDamage(StatsSO affectedStatSheet)
    {
        int finalDamage;

        if (phisicalDamage)
        {
            finalDamage = damage - affectedStatSheet.defense;
        }
        else
        {
            finalDamage = damage - affectedStatSheet.magicDefense;
        }

        affectedStatSheet.health -= Mathf.CeilToInt( finalDamage );
    }
}
