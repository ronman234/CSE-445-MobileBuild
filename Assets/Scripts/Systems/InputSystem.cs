using Unity.Entities;
using UnityEngine;

public class InputSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((InputComponent inputComponent) =>
        {
            //inputComponent.Movement = Input.GetAxis("Horizontal");

            inputComponent.Jump = Input.GetKeyDown(KeyCode.Space);
            inputComponent.Down = Input.GetKey(KeyCode.DownArrow);
            inputComponent.LeftTouchKey = Input.GetKey(KeyCode.A);
            inputComponent.RightTouchKey = Input.GetKey(KeyCode.D);
        });
    }
}