using Unity.Entities;
using UnityEngine;

public class PlatformSystem : ComponentSystem
{
    public InputComponent inputComponent;
    public MoveSpeedComponent moveSpeedComponent;
    public MobileInputComponent mobileInput;
    protected override void OnUpdate()
    {

        Entities.ForEach((InputComponent inputcomponent, MoveSpeedComponent moveSpeed, TagPlayerComponent tag, MobileInputComponent mInput) =>
        {
            inputComponent = inputcomponent;
            moveSpeedComponent = moveSpeed;
            mobileInput = mInput;
        });

        var time = Time.deltaTime;

        Entities.ForEach((PlatformComponent platformcomponent, PlatformEffector2D platformeffector2D, BoxCollider2D collider) =>
        {
            var timer = platformcomponent.waitTime;
            if ((inputComponent.Down == true ||  mobileInput.middleScreenTouch.deltaPosition.y < -30) && moveSpeedComponent.isGrounded == true) //checks to see if the player is pushing down and grounded 
            {
                collider.enabled = false;
            }
            
        });
    }
}
