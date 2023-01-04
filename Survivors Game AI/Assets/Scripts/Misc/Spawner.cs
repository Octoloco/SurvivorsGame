using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer;
    
    [SerializeField] private float scaleFactor;
    [SerializeField] private Factory EnemyFactory;
    [SerializeField] private float startTime;

    void Start()
    {
        timer = startTime;
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
        Vector2 position = Vector2.zero;
        int placement = Random.Range((int)0, (int)4);

        switch (placement)
        {
            case 0:
                position.x = Random.Range(transform.position.x - Camera.main.orthographicSize * Camera.main.aspect * scaleFactor, transform.position.x + Camera.main.orthographicSize * Camera.main.aspect * scaleFactor);
                position.y = transform.position.y - Camera.main.orthographicSize * scaleFactor;
                break;

            case 1:
                position.x = Random.Range(transform.position.x - Camera.main.orthographicSize * Camera.main.aspect * scaleFactor, transform.position.x + Camera.main.orthographicSize * Camera.main.aspect * scaleFactor);
                position.y = transform.position.y + Camera.main.orthographicSize * scaleFactor;
                break;

            case 2:
                position.y = Random.Range(transform.position.y - Camera.main.orthographicSize * scaleFactor, transform.position.y + Camera.main.orthographicSize * scaleFactor);
                position.x = transform.position.x - Camera.main.orthographicSize * Camera.main.aspect * scaleFactor;
                break;

            case 3:
                position.y = Random.Range(transform.position.y - Camera.main.orthographicSize * scaleFactor, transform.position.y + Camera.main.orthographicSize * scaleFactor);
                position.x = transform.position.x + Camera.main.orthographicSize * Camera.main.aspect * scaleFactor;
                break;
        }

        temp.transform.position = position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, new Vector3(Camera.main.orthographicSize * Camera.main.aspect * 2 * scaleFactor, Camera.main.orthographicSize * 2 * scaleFactor));
            
    }
}
