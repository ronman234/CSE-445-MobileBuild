using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class GargoyleAttackSystem : ComponentSystem
{
    

    protected override void OnUpdate()
    {
        BoxCollider2D spearCollider = null;
        Entities.ForEach((SpearComponent spear, BoxCollider2D collider) =>
        {
            spearCollider = collider;
        });

        Entities.ForEach((GargoyleTagComponent tag, BoxCollider2D collider, Animator anim, Transform translation, EnemyMovementComponent movement, SpriteRenderer renderer) =>
        {
            RaycastHit2D hit = Physics2D.Raycast(translation.position + movement.direction, movement.direction, 1);
            //Debug.DrawRay(translation.position, movement.direction, Color.black);
            if(hit.collider.tag == "Player")
            {
                anim.SetBool("Attack", true);
                spearCollider.enabled = true;
                //renderer.flipY = true;
            }
            else
            {
                anim.SetBool("Attack", false);
                spearCollider.enabled = false;
            }
        });
    }
}
