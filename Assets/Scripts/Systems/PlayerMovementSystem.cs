using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;
using Unity.Mathematics;
using Unity.Transforms;

public class PlayerMovementSystem : ComponentSystem
{

    protected override void OnUpdate()
    {
        var m_Input = Camera.main.GetComponent<MobileInputComponent>();
        var delta = Time.deltaTime;
        Entities.ForEach((PlayerMovementCompnent transformMovement, Transform translation) =>
        {
            //translation.position = m_Input.screenWorldPosition;
            if(m_Input.leftScreen)
            {
                translation.position += Vector3.left * transformMovement.MovementSpeed;
            }
            if(m_Input.rightScreen)
            {
                translation.position += Vector3.right * transformMovement.MovementSpeed;
            }
            
        });
    }
}
