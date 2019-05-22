using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Rigidbody2D rigidbody2D, InputComponent inputcomponent, MovementComponent movement, MobileInputComponent m_Input, SpriteRenderer sprite, Animator anim) =>
        {
            if (m_Input.leftScreen || inputcomponent.LeftTouchKey) //allows player movement with right arrow or D
            {
                //inputcomponent.RightTouchKey = true;
                rigidbody2D.velocity = new Vector2( Vector2.left.x * movement.speed, rigidbody2D.velocity.y);
                sprite.flipX = true;
                anim.SetFloat("Speed", 1);
            }
            else if ( m_Input.rightScreen || inputcomponent.RightTouchKey ) //allows player movement with left arrow or A
            {
                //inputcomponent.LeftTouchKey = true;
                rigidbody2D.velocity = new Vector2(Vector2.right.x * movement.speed, rigidbody2D.velocity.y);
                sprite.flipX = false;
                anim.SetFloat("Speed", 1);
            }
            else
            {
                anim.SetFloat("Speed", 0);
            }
        });
    }
}
