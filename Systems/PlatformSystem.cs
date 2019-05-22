using Unity.Entities;
using UnityEngine;

public class PlatformSystem : ComponentSystem
{
    public InputComponent m_inputComponent;
    public MoveSpeedComponent m_moveSpeedComponent;

    protected override void OnUpdate()
    {

       Entities.ForEach((InputComponent inputcomponent, MoveSpeedComponent moveSpeed) => 
        {
            m_inputComponent = inputcomponent;
            
            m_moveSpeedComponent = moveSpeed;

        });

        Entities.ForEach((BoxCollider2D collider, PlatformEffector2D platform) =>
        {
            if (m_inputComponent.Down == true && m_moveSpeedComponent.isGrounded == true) //checks to see if the player is pushing down and grounded 
            {
                collider.enabled = false; 
            }
            else collider.enabled |= (m_inputComponent.Down == false && m_moveSpeedComponent.isGrounded == true);
        });
    }
}
