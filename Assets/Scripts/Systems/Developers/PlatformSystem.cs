using Unity.Entities;
using UnityEngine;

public class PlatformSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((InputComponent inputcomponent, MovementComponent movement, TagPlayerComponent tag, MobileInputComponent mInput) =>
        {
        });

        var time = Time.deltaTime;

        Entities.ForEach((PlatformComponent platformcomponent, PlatformEffector2D platformeffector2D, BoxCollider2D collider) =>
        {
            var timer = platformcomponent.waitTime;
            
        });
    }
}
