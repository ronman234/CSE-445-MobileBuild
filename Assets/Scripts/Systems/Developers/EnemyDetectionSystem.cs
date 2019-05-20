using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class EnemyDetectionSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((EnemyMovementComponent enemyMovement, Transform translation) =>
        {
            RaycastHit2D hit = Physics2D.Raycast(translation.position + enemyMovement.direction, translation.position + enemyMovement.direction, .1f);
            if (hit)
            {
                if (hit.collider.tag == "Wall")
                {
                    if (enemyMovement.isMovingRight)
                    {
                        enemyMovement.direction = Vector3.left;
                        enemyMovement.isMovingRight = false;
                    }
                    else
                    {
                        enemyMovement.direction = Vector3.right;
                        enemyMovement.isMovingRight = true;
                    }
                }
            }
        });
    }
}
