using Unity.Entities;
using UnityEngine;

public class PlayeToEnemyrDamageSystem : ComponentSystem
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

                if (playerCollider.IsTouching(collider))
                {
                    Debug.Log("collider worked");
                    Health.currentHealth -= 1;

                    if (Health.currentHealth == 0 && collider.tag == "Bat")
                    {
                        Debug.Log("destroy enemy");
                        Object.FindObjectOfType<AudioManager>().Play("SquishedBat");
                        MonoBehaviour.Destroy(tag.gameObject);
                    }

                if (Health.currentHealth == 0 && collider.tag == "Gargoyle")
                {
                    Debug.Log("destroy enemy");
                    Object.FindObjectOfType<AudioManager>().Play("RockCrumble");
                    MonoBehaviour.Destroy(tag.gameObject);
                }

                /*
                if (Hit.collider.IsTouching(collider))
                {

                }*/
            }
        
        });
    }
}

