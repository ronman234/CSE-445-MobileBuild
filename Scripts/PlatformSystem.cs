using Unity.Entities;
using UnityEngine;

public class PlatformSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        //InputComponent inputComponent;
       // MoveSpeedComponent moveSpeedComponent;

       Entities.ForEach((InputComponent inputcomponent, MoveSpeedComponent moveSpeed) =>
        {
            //inputcomponent.Down = inputComponent;  
           //moveSpeed.isGrounded = moveSpeedComponent;

        });


        Entities.ForEach((PlatformComponent platformcomponent, PlatformEffector2D platformeffector2D) =>
        {
            /*if (inputComponent == true && moveSpeedComponent == true) //checks to see if the player is pushing down and grounded 
            {
                if (platformcomponent.waitTime <= 0)
                {
                    platformeffector2D.rotationalOffset = 180f; //flips platform 180 degrees for short duration
                    platformcomponent.waitTime = 0.5f;
                    platformeffector2D.rotationalOffset = 0f;
                }
                else
                {
                    platformcomponent.waitTime -= 1.0 * Time.deltaTime;

                }
            }*/
        });
    }
}
