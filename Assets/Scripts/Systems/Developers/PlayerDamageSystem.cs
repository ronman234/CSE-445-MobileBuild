using Unity.Entities;
using UnityEngine;

public class PlayerDamageSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        BoxCollider2D playerCollider = null;
        Vector2 playerPosition = Vector2.zero;

        Entities.ForEach((TagGroundChecker check, BoxCollider2D collider, Transform translate) =>
        {
            playerCollider = collider;
            playerPosition = translate.position;
        });

        Entities.ForEach((TagEnemyComponent tag, HealthComponent Health, BoxCollider2D collider) =>
        {
        // RaycastHit2D Hit = Physics2D.Raycast(playerPosition - Vector2.down * .25f, Vector2.down, .1f, 11);

                if (playerCollider.IsTouching(collider)) //if ground and enemy colliders touch
            {
                    Debug.Log("collider worked");
                    Health.currentHealth -= 1;           //enemy loses 1 health

                    if (Health.currentHealth == 0)       //if enemy health equals 0
                    {
                        Debug.Log("destroy enemy");
                        Object.FindObjectOfType<AudioManager>().Play("SquishedBat");
                        MonoBehaviour.Destroy(tag.gameObject);  //destroy enemy 
                    }
                }
        
        });
    }
}

