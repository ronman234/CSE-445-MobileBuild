using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

public class PlayerMovementSystem : ComponentSystem
{

    protected override void OnUpdate()
    {
        var m_Input = Camera.main.GetComponent<MobileInputComponent>();
        var delta = Time.deltaTime;
        Entities.ForEach((PlayerMovementCompnent transformMovement, Transform translation) =>
        {
            if(m_Input.leftScreen)
            {
                translation.position += Vector3.left * transformMovement.MovementSpeed * delta;
            }
            if(m_Input.rightScreen)
            {
                translation.position += Vector3.right * transformMovement.MovementSpeed * delta;
            }
            if(m_Input.middleScreen)
            {
                if(m_Input.middleScreenTouch.deltaPosition.y > 30)
                {
                    translation.position += Vector3.up * 1;
                }
                else if(m_Input.middleScreenTouch.deltaPosition.y < -30)
                {
                    translation.position += Vector3.down * 1;
                }
            }
            
        });
    }
}
