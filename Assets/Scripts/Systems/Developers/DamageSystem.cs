using Unity.Entities;
using UnityEngine;

//Does not have collider and did not have time to test
public class DamageSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((DamageComponent damageComponent, LifeComponent lifeComponent, EnemyComponent enemyComponent) =>
        {
            // Check if gameobject has an Enemy script

                //Check if grounded
                if (damageComponent.isGrounded)
                {
                    Debug.Log("Player is grounded");
                }
                else if (!damageComponent.hitLeftFoot && !damageComponent.hitLeftHeel && !damageComponent.hitRightFoot && !damageComponent.hitRightHeel)
                {
                    Debug.Log("Feet Raycast NOT detecting a collider.");
                }
                else
                { //various ways to jump and damage bat
                    if (damageComponent.hitLeftFoot)
                    {
                        if (damageComponent.hitLeftFoot == enemyComponent)
                        {
                            damageComponent.jumpedOnBat = true;
                        }
                    }
                    else if (damageComponent.hitLeftHeel)
                    {
                        if (damageComponent.hitLeftHeel == enemyComponent)
                        {
                            damageComponent.jumpedOnBat = true;
                        }
                    }
                    else if (damageComponent.hitRightFoot)
                    {
                        if (damageComponent.hitRightFoot == enemyComponent)
                        {
                            damageComponent.jumpedOnBat = true;
                        }
                    }
                    else if (damageComponent.hitRightHeel)
                    {
                        if (damageComponent.hitRightHeel == enemyComponent)
                        {
                            damageComponent.jumpedOnBat = true;
                        }
                    }
                    if (damageComponent.jumpedOnBat)
                    {
                        Debug.Log("Jumped on Bat");
                        lifeComponent.removeHitPoints(1);
                    }
                }
             //various ways to jump and damage player 1 or player 2
            
            
        });
    }
}

