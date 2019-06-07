using Unity.Entities;
using UnityEngine;

public class FourWayMovingPlatformSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var time = Time.deltaTime;

        Entities.ForEach((FourWayMovingPlatformComponent movingplatform, BoxCollider2D collider, TagPlatform tag) =>
        {
            //problem with disappearing platform resolved by setting z axis to -5 in Camera script in Main Camera

            if (collider.IsTouchingLayers(LayerMask.GetMask("Default")))
            {
                movingplatform.player.transform.SetParent(movingplatform.platform.transform);
            }
            else
            {
                movingplatform.player.transform.parent = null; 
            }

            movingplatform.currentPoint = movingplatform.points[movingplatform.pointSelection];

            movingplatform.platform.transform.position = Vector3.MoveTowards(movingplatform.platform.transform.position, movingplatform.currentPoint.position, time * movingplatform.moveSpeed);

            if (movingplatform.platform.transform.position == movingplatform.currentPoint.position)
            {
                movingplatform.pointSelection++;

                if (movingplatform.pointSelection == movingplatform.points.Length)
                {
                    movingplatform.pointSelection = 0;
                }

                movingplatform.currentPoint = movingplatform.points[movingplatform.pointSelection];

            }
        });
    }

}
