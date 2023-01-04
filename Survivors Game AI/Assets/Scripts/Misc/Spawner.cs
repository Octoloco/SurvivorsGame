using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector2 dimensions0;
    private Vector2 dimensions1;

    private Factory EnemyFactory;

    void Start()
    {
        dimensions0 = new Vector2(0 - (transform.localScale.x/2), 0 - (transform.localScale.y / 2));
        dimensions1 = new Vector2(0 + (transform.localScale.x/2), 0 + (transform.localScale.y / 2));
    }

    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        GameObject temp = EnemyFactory.CreateItem();
        Vector2 position;
        position.x = Random.Range(dimensions0.x, dimensions1.x);
        position.y = Random.Range(dimensions0.y, dimensions1.y);

        temp.transform.position = position;
    }
}
