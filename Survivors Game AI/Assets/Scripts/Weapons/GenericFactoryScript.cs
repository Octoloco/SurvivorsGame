using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericFactoryScript : MonoBehaviour
{
    [Header("Factory Setup")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private int instances;
    [SerializeField] private Transform initialGenericSpawnPlace;

    [SerializeField] private List<GameObject> availableObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> inUseObjects = new List<GameObject>();

    void Start()
    {
        GameObject temp;

        for (int i = 0; i < instances; i++)
        {
            temp = Instantiate(prefab, initialGenericSpawnPlace.position, Quaternion.identity, transform);
            availableObjects.Add(temp);
            temp.SetActive(false);
        }
    }

    public GameObject SpawnItem(Vector3 position, Quaternion rotation)
    {
        GameObject temp = null;

        if (availableObjects.Count > 0)
        {
            temp = availableObjects[0];
            temp.SetActive(true);
            temp.transform.position = position;
            temp.transform.rotation = rotation;
            availableObjects.Remove(temp);
        }
        else
        {
            temp = Instantiate(prefab, initialGenericSpawnPlace.position, Quaternion.identity, transform);
            temp.transform.position = position;
            temp.transform.rotation = rotation;
            temp.SetActive(true);
        }

        return temp;
    }

    public void DestroyObject(GameObject item)
    {
        item.transform.position = initialGenericSpawnPlace.position;
        item.transform.rotation = Quaternion.identity;
        availableObjects.Add(item);
        item.SetActive(false);
    }

}
