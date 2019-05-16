using Unity.Entities;
using UnityEngine;

public class MovingPlatformSystem : ComponentSystem
{
    public MovingPlatformComponent platform;

    protected override void OnUpdate()
    {
        var time = Time.deltaTime;

        Entities.ForEach((MovingPlatformComponent movingplatform) => 
        {
            movingplatform.currentPoint = movingplatform.points[movingplatform.pointSelection];

            movingplatform.platform.transform.position = Vector3.MoveTowards (movingplatform.platform.transform.position, movingplatform.currentPoint.position, time * movingplatform.moveSpeed);

            if (movingplatform.platform.transform.position == movingplatform.currentPoint.position)
            {
                movingplatform.pointSelection++;

                if (movingplatform.pointSelection == movingplatform.points.Length)
                {
                    movingplatform.pointSelection = 0;
                }
                movingplatform.currentPoint = movingplatform.points [movingplatform.pointSelection];
            }
        });
    }

}
