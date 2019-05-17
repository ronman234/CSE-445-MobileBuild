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
            if(Physics.Raycast(translation.position, enemyMovement.direction, 1))
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
        });

    }
}
