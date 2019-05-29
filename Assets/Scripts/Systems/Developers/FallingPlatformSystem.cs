using Unity.Entities;
using UnityEngine;

public class FallingPlatformSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var time = Time.deltaTime;

        Entities.ForEach((TagPlatform tag, Rigidbody2D rb, FallingPlatformComponent falling, BoxCollider2D collider) =>
        {
            if (collider.IsTouchingLayers(LayerMask.GetMask("Default")))
            {
                falling.isOnPlatform = true;

                if (falling.isOnPlatform == true)
                {
                    falling.fallTimer += time;

                    if (falling.fallTimer > 0.5)
                    {
                        rb.isKinematic = false;
                    }
                }
            }
        });
    }


}
