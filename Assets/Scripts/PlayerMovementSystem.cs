using Unity.Entities;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var m_Input = Camera.main.GetComponent<MobileInputComponent>();
        var delta = Time.deltaTime;
        Entities.ForEach((TagPlayerComponent tagPlayer, Rigidbody2D rigidbody2D, InputComponent inputcomponent, MoveSpeedComponent movespeedcomponent) =>
        {

            if (m_Input.leftScreen || inputcomponent.LeftTouchKey) //allows player movement with right arrow or D
            {
                //inputcomponent.RightTouchKey = true;
                rigidbody2D.velocity = new Vector2( Vector2.left.x* movespeedcomponent.moveSpeed, rigidbody2D.velocity.y);
                movespeedcomponent.transform.eulerAngles = new Vector2(0, 0); //faces the player object in the right direction
            }
            

            if (m_Input.rightScreen || inputcomponent.RightTouchKey) //allows player movement with left arrow or A
            {
                //inputcomponent.LeftTouchKey = true;
                rigidbody2D.velocity = new Vector2(Vector2.right.x * movespeedcomponent.moveSpeed, rigidbody2D.velocity.y);
                movespeedcomponent.transform.eulerAngles = new Vector2(0, 180);  //faces the player object in the left direction
            }
            

            //Does the ground check for the player
            movespeedcomponent.isGrounded = Physics2D.OverlapCircle(movespeedcomponent.groundCheck.position, movespeedcomponent.groundCheckRadius, movespeedcomponent.Ground);


            if (movespeedcomponent.isGrounded == true && (inputcomponent.Jump || m_Input.middleScreenTouch.deltaPosition.x > 30)) //allows the player to jump
            {
                //inputcomponent.MiddleTouchKey = true;
                movespeedcomponent.extraJumpsValue = movespeedcomponent.extraJumps;  //stores values of extra jumps
                rigidbody2D.velocity = Vector2.up * movespeedcomponent.jumpSpeed;    //physics movement up the y axis
            }
            

            //allows the player extra jumps while in air
            if ((inputcomponent.Jump || m_Input.middleScreenTouch.deltaPosition.x > 30) && movespeedcomponent.extraJumpsValue > 0 && movespeedcomponent.isGrounded == false)
            {
                //inputcomponent.MiddleTouchKey = true;
                rigidbody2D.velocity = Vector2.up * movespeedcomponent.jumpSpeed; //physics movement for extra jumps
                movespeedcomponent.extraJumpsValue--;  //decreases each extra jump from player
            }
            else
            {
                //inputcomponent.MiddleTouchKey = false;
                inputcomponent.Jump = false; //returns to ground

            }
        });
    }
}
