using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    protected float movementSpeed = 0;
    protected int damage = 0;
    protected int magicPower = 0;
    protected float attackSpeed = 0;
    protected int magicDefense = 0;
    protected int defense = 0;

    public override void ResetActor()
    {
        movementSpeed = statSheet.movementSpeed;
        damage = statSheet.damage;
        magicPower = statSheet.magicPower;
        attackSpeed = statSheet.attackSpeed;
        magicDefense = statSheet.magicDefense;
        defense = statSheet.defense;
    }
}
