using Unity.Entities;
using UnityEngine;

public class MovingPlatformSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var time = Time.time;

        Entities.ForEach((MovingPlatformComponent moving, BoxCollider2D collider) =>
        {
            moving.startPos = moving.transform.localPosition;

            if (collider.IsTouchingLayers(LayerMask.GetMask("Default"))) //parents the player to the platform
            {
                moving.player.transform.SetParent(moving.floatingplatform.transform);
            }
            else
            {
                moving.player.transform.parent = null;   //removes player from the platform 
            }

            if (moving.isVertical == false)   //moves platform horizontally
            {
                moving.transform.position = new Vector2(PingPong(time * moving.speed, -moving.leftLengthDistance, moving.rightLengthDistance), moving.transform.position.y);
            }

            if (moving.isVertical == true)   //moves platform vertically
            {
                moving.transform.position = new Vector2(moving.transform.position.x, PingPong(time * moving.speed, -moving.leftLengthDistance, moving.rightLengthDistance));
            }

            float PingPong(float t, float minLength, float maxLength)  //math for moving the platform from A to B and B to A in a loop
            {
                return Mathf.PingPong(t, maxLength - minLength) + minLength;
            }
        });
    }
}
