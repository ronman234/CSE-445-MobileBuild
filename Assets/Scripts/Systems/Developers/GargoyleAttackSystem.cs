using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class GargoyleAttackSystem : ComponentSystem
{
    

    protected override void OnUpdate()
    {
        BoxCollider2D playerCollider = null;

        Entities.ForEach((TagPlayerComponent player, BoxCollider2D collider) =>
        {
            playerCollider = collider;
        });

        Entities.ForEach((GargoyleTagComponent tag, BoxCollider2D collider, Animator anim, Transform translation, SpriteRenderer renderer) =>
        {
            if(collider.IsTouching(playerCollider))
            {
                anim.SetBool("Attack", true);
            }
            anim.SetBool("Attack", false);
        });
    }
}
