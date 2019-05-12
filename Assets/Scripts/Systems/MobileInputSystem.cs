using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MobileInputSystem : ComponentSystem
{
    MobileInputComponent m_Input;
    //protected override void OnCreate()
    //{
    //    m_Input = Camera.main.GetComponent<MobileInputComponent>();
    //}

    protected override void OnUpdate()
    {
        m_Input = Camera.main.GetComponent<MobileInputComponent>();
        for (int i = 0; i < Input.touchCount; i++)
        {
            if(Input.touches[i].position.x > 0 && Input.touches[i].position.x <= 540)
            {
                m_Input.leftScreen = true;
            }
            else if (Input.touches[i].position.x > 540 && Input.touches[i].position.x <= 1620)
            {
                m_Input.middleScreen = true;
            }
            else if (Input.touches[i].position.x > 1620 && Input.touches[i].position.x <= 2160)
            {
                m_Input.rightScreen = true;
            }

            m_Input.screenWorldPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

            if(Input.touches[i].phase == TouchPhase.Ended)
            {
                m_Input.leftScreen = m_Input.rightScreen = m_Input.middleScreen = false;
            }
        }
    }
}
