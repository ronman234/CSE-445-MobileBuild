using Unity.Entities;
using UnityEngine;

public class OneMovingPlatformSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var time = Time.time;

        Entities.ForEach((OneWayMovingPlatformComponent moving, BoxCollider2D collider, Transform position) =>
        { 

            if (collider.IsTouchingLayers(LayerMask.GetMask("Default"))) //parents the player to the platform
            {
                moving.player.transform.SetParent(moving.floatingplatform.transform);
            }
            else
            {
                moving.player.transform.parent = null;   //removes player from the platform 
            }

            if (moving.isVertical == false )  //moves platform horizontally
            {
                position.position = new Vector2(PingPong(time * moving.speed, -moving.negativeLengthDistance + position.position.x, moving.positiveLengthDistance + position.position.x), position.position.y);
            }

            else if (moving.isVertical == true)   //moves platform vertically
            {
                position.position = new Vector2(position.position.x, PingPong(time * moving.speed, -moving.negativeLengthDistance + position.position.y, moving.positiveLengthDistance + position.position.y));
            }

            float PingPong(float t, float minLength, float maxLength)  //math for moving the platform from A to B and B to A in a loop
            {
                return Mathf.PingPong(t, maxLength - minLength) + minLength;
            }
        });
    }
}
