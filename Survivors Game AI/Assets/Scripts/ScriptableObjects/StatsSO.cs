using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/StatSheet")]
public class StatsSO : ScriptableObject
{
    [Header ("Main Stats")]
    public int health = 0;
    public float movementSpeed = 0;
    [Header("Offensive Stats")]
    public int damage = 0;
    public int magicPower = 0;
    public float attackSpeed = 0;
    public int critChance = 0;
    public int critDamageMod = 2;
    [Header("Defensive Stats")]
    public int magicDefense = 0;
    public int defense = 0;
}
