using Unity.Entities;
using UnityEngine;

public class EnemyDamageSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var time = Time.deltaTime;
        BoxCollider2D enemyCollider = null;
        Vector2 enemyPosition = Vector2.zero;

        Entities.ForEach((TagEnemyComponent tag, BoxCollider2D collider, Transform translate) =>
        {
            enemyCollider = collider;
            enemyPosition = translate.position;
        });

        Entities.ForEach((TagPlayerComponent tag, HealthComponent Health, InvincibleComponent inv, LivesComponent lifes, BoxCollider2D collider) =>
        {
            if (enemyCollider.IsTouching(collider))
            {
                Debug.Log("collider worked");
                if (Health.currentHealth > 0)
                {
                    Debug.Log("lose 1 health");
                    Health.currentHealth -= 1;
                    Physics2D.IgnoreLayerCollision(0, 10, true);
                    Physics2D.IgnoreLayerCollision(8, 10, true);
                    inv.startTimer = true;
                    Object.FindObjectOfType<AudioManager>().Play("PlayerHit");
                }
                if (Health.currentHealth == 0)
                {
                    lifes.lives -= 1;
                    Health.currentHealth = 3;
                }
            }
            if (inv.startTimer == true)
            {
                inv.invTimer += time;

                if (inv.invTimer >= 2f)
                {
                    Debug.Log("reset timer");
                    Physics2D.IgnoreLayerCollision(0, 10, false);
                    Physics2D.IgnoreLayerCollision(8, 10, false);
                    inv.invTimer = 0f;
                    inv.startTimer = false;
                }
            }
            if (lifes.lives == 0)
            {
                Health.currentHealth = 0;
                Debug.Log("destroy player");
                MonoBehaviour.Destroy(tag.gameObject);
            }
        });
    }
}
