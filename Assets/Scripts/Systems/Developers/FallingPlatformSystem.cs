using Unity.Entities;
using UnityEngine;

public class FallingPlatformSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((InputComponent inputcomponent, MovementComponent movement) =>
        {
        });

        Entities.ForEach((FallingPlatformComponent fallingplatform, Rigidbody2D rigidbody2D) =>
        {

        });
    }


}
