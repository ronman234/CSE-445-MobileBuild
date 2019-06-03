using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class GargoyleRaycastSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((EnemyMovementComponent enemyMovement, Transform translation, GargoyleTagComponent gTag, SpriteRenderer sprite) =>
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(translation.position.x + 0.1f, translation.position.y) + enemyMovement.direction, Vector3.down, 1);
            Debug.DrawRay(new Vector3(translation.position.x + 0.1f, translation.position.y) + enemyMovement.direction, Vector3.down, Color.green);
            if (hit.collider.tag == "Wall")
            {
                if (enemyMovement.isMovingRight)
                {
                    enemyMovement.direction = Vector3.left;
                    enemyMovement.isMovingRight = false;
                    sprite.flipX = true;
                }
                else
                {
                    enemyMovement.direction = Vector3.right;
                    enemyMovement.isMovingRight = true;
                    sprite.flipX = false;
                }
            }
            
        });
    }
}
