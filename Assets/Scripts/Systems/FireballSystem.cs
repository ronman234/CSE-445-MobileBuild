using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class FireballSystem : ComponentSystem
{
    protected override void OnUpdate()
    {   //Shoots Fireball projectile
        Entities.ForEach((FireballComponent fireballComponent, Transform transform) =>
        {
           transform.position += (Vector3)fireballComponent.targetDir * fireballComponent.speed * Time.deltaTime;
        });
    }
    //Collider still needed
}
