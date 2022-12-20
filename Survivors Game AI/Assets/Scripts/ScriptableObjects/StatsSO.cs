using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/StatSheet")]
public class StatsSO : ScriptableObject
{
    [Header ("Main Stats")]
    public float health = 0;
    public float movementSpeed = 0;
    [Header("Offensive Stats")]
    public float damage = 0;
    public float magicPower = 0;
    public float attackSpeed = 0;
    public float critChance = 0;
    public float critDamageMod = 2;
    [Header("Defensive Stats")]
    public float magicDefense = 0;
    public float defense = 0;
}
