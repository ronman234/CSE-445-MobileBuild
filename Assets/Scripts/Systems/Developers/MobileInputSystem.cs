using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MobileInputSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Rigidbody2D rigidbody2D, InputComponent inputcomponent, MovementComponent movespeedcomponent, MobileInputComponent m_Input) =>
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if(Input.touches[i].position.x > 0 && Input.touches[i].position.x <= 540)
                {
                    m_Input.leftScreen = true;
                }
                else if (Input.touches[i].position.x > 540 && Input.touches[i].position.x <= 1620)
                {
                    m_Input.middleScreen = true;
                    m_Input.middleScreenTouch = Input.touches[i];
                }
                else if (Input.touches[i].position.x > 1620 && Input.touches[i].position.x <= 2160)
                {
                    m_Input.rightScreen = true;
                }

                if(Input.touches[i].phase == TouchPhase.Ended)
                {
                    m_Input.leftScreen = m_Input.rightScreen = m_Input.middleScreen = false;
                }
            }

        });
        
    }
}
