using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class GroundedSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        bool grounded = false;

        Entities.ForEach((TagGroundChecker check, BoxCollider2D collider) =>
        {
            if ( collider.IsTouchingLayers( 1 << 8 ) )
            {
                grounded = true;
            }
        });

        Entities.ForEach((TagPlayerComponent player, JumpComponent jump, Rigidbody2D rb) =>
        {
            jump.canJump = grounded;
        });
    }
}
