using Unity.Entities;
using UnityEngine;

public class CircularPlatformSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var time = Time.fixedTime;

        Entities.ForEach((TagPlatform tag ,CircularMovingPlatformComponent moving, BoxCollider2D collider) =>
        {
            moving.PosX = moving.Platform.position.x + Mathf.Cos(moving.Angle) * moving.RotationRadius;
            moving.PosY = moving.Platform.position.y + Mathf.Sin(moving.Angle) * moving.RotationRadius;
            moving.transform.position = new Vector2(moving.PosX, moving.PosY);
            moving.Angle = moving.Angle + Time.deltaTime * moving.AngularSpeed;

            if (moving.Angle >= 360f)
                moving.Angle = 0f;

            if (collider.IsTouchingLayers(LayerMask.GetMask("Default"))) //parents the player to the platform
            {
                moving.Player.transform.SetParent(moving.Platform.transform);
            }
            else
            {
                moving.Player.transform.parent = null;   //removes parenting from platform
            }



        });
    }
}
