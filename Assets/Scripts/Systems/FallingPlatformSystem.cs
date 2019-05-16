using Unity.Entities;
using UnityEngine;

public class FallingPlatformSystem : ComponentSystem
{
    public MoveSpeedComponent m_moveSpeedComponent;

    protected override void OnUpdate()
    {
        Entities.ForEach((InputComponent inputcomponent, MoveSpeedComponent moveSpeed) =>
        {
            m_moveSpeedComponent = moveSpeed;

        });

        Entities.ForEach((FallingPlatformComponent fallingplatform, Rigidbody2D rigidbody2D) =>
        {

            if (m_moveSpeedComponent.gameObject.tag == "Player" )
            {
                rigidbody2D.isKinematic = false;

            }

        });
    }


}
