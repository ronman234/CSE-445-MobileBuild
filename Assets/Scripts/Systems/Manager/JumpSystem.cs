using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class JumpSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((TagPlayerComponent player, JumpComponent jump, InputComponent input, MobileInputComponent mobileInput, Rigidbody2D rb) =>
        {
            if ( input.Jump && jump.canJump || mobileInput.middleScreen && jump.canJump )
            {
                rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * jump.height);
                jump.canJump = false;

            }
        });
    }
}
