using Unity.Entities;
using UnityEngine;

public class PlatformSystem : ComponentSystem
{
    public InputComponent m_inputComponent;
    public JumpComponent checkground;

    protected override void OnUpdate()
    {
        Entities.ForEach((InputComponent inputcomponent, JumpComponent ground, TagPlayerComponent tag, MobileInputComponent mInput) =>
        {
            m_inputComponent = inputcomponent;

            checkground = ground;
        });

        Entities.ForEach((TagPlatform tag, PlatformEffector2D platformeffector2D, BoxCollider2D collider) =>
        {
            if (m_inputComponent.Down == true && checkground.canJump == true) //checks to see if the player is pushing down and grounded 
            {
                collider.enabled = false;
            }
            else collider.enabled |= (m_inputComponent.Down == false && checkground.canJump == true);

        });
    }
}
