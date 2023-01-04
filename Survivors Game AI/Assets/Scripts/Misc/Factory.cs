using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private int numberOfAvailbaleItems;
    private List<GameObject> avaibleItems = new List<GameObject>();

    private void InitializeFactory()
    {
        if (item != null)
        {
            GameObject temp;
            for (int i = 0; i < numberOfAvailbaleItems; i++)
            {
                temp = Instantiate(item, Vector3.zero, Quaternion.identity);
                temp.transform.parent = transform;
            }
        }
        else
        {
            Debug.LogError("Factory has no items to spawn, add items or delete this factory", this);
        }
    }

    public GameObject CreateItem()
    {
        
        return null;
    }
}
