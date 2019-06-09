using Unity.Entities;
using UnityEngine;

public class EnemyDamageSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var time = Time.deltaTime;
        BoxCollider2D enemyCollider = null;
        Vector2 enemyPosition = Vector2.zero;
        Vector3 respawnPosition = new Vector3 (0, 0, -1);

        Entities.ForEach((TagEnemyComponent tag, BoxCollider2D collider, Transform translate) =>
        {
            enemyCollider = collider;
            enemyPosition = translate.position;
        });

        Entities.ForEach((TagPlayerComponent tag, HealthComponent Health, InvincibleComponent inv, LivesComponent lifes, BoxCollider2D collider, Transform translate) =>
        {
            if (enemyCollider.IsTouching(collider)) //if enemy and player colliders touch
            {
                Debug.Log("collider worked");
                if (Health.currentHealth > 0) //and if player health is greater than 0
                {
                    Debug.Log("lose 1 health");
                    Health.currentHealth -= 1;                      //player loses 1 health
                    Physics2D.IgnoreLayerCollision(0, 10, true);    //sets true to ignore player and enemy collision layers
                    Physics2D.IgnoreLayerCollision(8, 10, true);    //set true to ignore ground and enemy collision layers 
                    inv.startTimer = true;                          //start timer is true
                    Object.FindObjectOfType<AudioManager>().Play("PlayerHit");
                    inv.invincible.enabled = false;
                }
                if (Health.currentHealth == 0)              //if current health equals 0 
                {
                    lifes.lives -= 1;                       //player loses 1 life
                    Health.currentHealth = 3;               //reset player current health to 3
                    translate.position = respawnPosition;   //change player location to respawn location
                }
            }
            if (inv.startTimer == true)                             //if start timer is true
            {
                inv.invincible.enabled = !inv.invincible.enabled;   //rendered player begins to blink
                inv.invTimer += time;                               //start invincible timer

                if (inv.invTimer >= 2f)                              //if invincible timer is equal or greater then 2 seconds
                {
                    Debug.Log("reset timer");
                    Physics2D.IgnoreLayerCollision(0, 10, false);   //sets false to ignore player and enemy collision layers
                    Physics2D.IgnoreLayerCollision(8, 10, false);   //sets false to ignore ground and enemy collision layers 
                    inv.invTimer = 0f;                              //reset timer
                    inv.startTimer = false;                         //startTimer false                             
                    inv.invincible.enabled = true;                 //rendered player stops blinking
                }
                if (lifes.lives == 0)                       // if player lives equal 0
                {
                    Health.currentHealth = 0;               //current health is also 0
                    Debug.Log("destroy player");
                    MonoBehaviour.Destroy(tag.gameObject);  //destroy player
                }
            }
        });
    }
}
