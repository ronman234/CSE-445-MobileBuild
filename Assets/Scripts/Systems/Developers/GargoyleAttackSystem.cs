using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class GargoyleAttackSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((GargoyleTagComponent tag, BoxCollider2D collider, Animator anim, Transform translation, EnemyMovementComponent movement, SpriteRenderer renderer) =>
        {
            RaycastHit2D hit = Physics2D.Raycast(translation.position , movement.direction, 1);
            if(hit.collider.tag == "Player")
            {
                anim.SetBool("attack", true);
                //renderer.flipY = true;
            }
        });
    }
}
