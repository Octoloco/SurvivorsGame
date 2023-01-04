using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private int numberOfAvailbaleItems;
    private List<GameObject> avaibleItems = new List<GameObject>();

    private void Awake()
    {
        InitializeFactory();
    }

    private void InitializeFactory()
    {
        if (item != null)
        {
            GameObject temp;
            for (int i = 0; i < numberOfAvailbaleItems; i++)
            {
                temp = Instantiate(item, Vector3.zero, Quaternion.identity);
                temp.transform.parent = transform;
                temp.SetActive(false);
                avaibleItems.Add(temp);
            }
        }
        else
        {
            Debug.LogError("Factory has no items to spawn, add items or delete this factory", this);
        }
    }

    public GameObject CreateItem()
    {
        GameObject finalItem = null;

        if (avaibleItems.Count != 0)
        {
            finalItem = avaibleItems[0];
            finalItem.SetActive(true);
            avaibleItems.Remove(finalItem);
            finalItem.transform.parent = null;
        }
        else
        {
            GameObject temp = Instantiate(item, Vector3.zero, Quaternion.identity);
            temp.transform.parent = null;
            temp.SetActive(true);

            finalItem = temp;
        }
        finalItem.GetComponent<Actor>().ResetActor();
        finalItem.GetComponent<Actor>().ActivateActor();
        return finalItem;
    }

    public void DestroyItem(GameObject itemToDestroy)
    {
        itemToDestroy.SetActive(false);
        if (itemToDestroy.GetComponent<Actor>())
        {
            itemToDestroy.GetComponent<Actor>().ResetActor();
            itemToDestroy.GetComponent<Actor>().DeactivateActor();
        }
        avaibleItems.Add(itemToDestroy);
    }
}
