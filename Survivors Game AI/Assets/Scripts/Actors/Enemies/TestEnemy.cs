using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    private GameObject target;
    private Vector2 direction;

    void Start()
    {
        FindTarget();
    }

    void Update()
    {
        direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * Time.deltaTime * movementSpeed);
    }

    private void FindTarget()
    {
        IList<PlayerFollower> followers = GlobalManagers.actorManager.GetPlayerFollowers();
        int rnd = Random.Range(0, followers.Count);
        target = followers[rnd].gameObject;
    }
}
