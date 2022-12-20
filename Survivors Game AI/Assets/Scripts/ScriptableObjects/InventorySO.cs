using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory")]
public class InventorySO : ScriptableObject
{
    public List<Weapon> weapons = new List<Weapon>();
    public List<PassiveItem> passiveItems = new List<PassiveItem>();
}
