using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector2 dimensions0;
    private Vector2 dimensions1;
    private float timer = 0;

    [SerializeField] private Factory EnemyFactory;
    [SerializeField] private float startTime;

    void Start()
    {
        dimensions0 = new Vector2(0 - (transform.localScale.x/2), 0 - (transform.localScale.y / 2));
        dimensions1 = new Vector2(0 + (transform.localScale.x/2), 0 + (transform.localScale.y / 2));
    }

    void Update()
    {
        if (timer <= 0)
        {
            SpawnEnemy();
            timer = startTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        GameObject temp = EnemyFactory.CreateItem();
        Vector2 position;
        if (Random.Range((int)0, (int)2) == 0)
        {
            position.x = Random.Range(dimensions0.x, dimensions1.x);
            if (Random.Range((int)0, (int)2) == 0)
            {
                position.y = dimensions0.y;
            }
            else
            {
                position.y = dimensions1.y;
            }
        }
        else
        {
            if (Random.Range((int)0, (int)2) == 0)
            {
                position.x = dimensions0.x;
            }
            else
            {
                position.x = dimensions1.x;
            }
            position.y = Random.Range(dimensions0.y, dimensions1.y);
        }

        temp.transform.position = position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
