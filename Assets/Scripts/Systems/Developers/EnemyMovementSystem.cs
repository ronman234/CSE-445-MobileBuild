using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class EnemyMovementSysytem : ComponentSystem
{   
    protected override void OnUpdate()
    {
        float time = Time.deltaTime;

        Entities.ForEach((EnemyMovementComponent enemyMovement, Transform translation) =>
        {
            if(enemyMovement.isMovingRight)
            {
                translation.position += enemyMovement.direction * enemyMovement.moveSpeed * time;
            }
            else
            {
                translation.position += enemyMovement.direction * enemyMovement.moveSpeed * time;
            }
        });
    }
}
