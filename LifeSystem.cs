using Unity.Entities;
using UnityEngine;

public class LifeSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        //Health system for players and enemy
        Entities.ForEach((LifeComponent lifeComponent) =>
        {
            lifeComponent.timerDmg += Time.deltaTime;

            for (int i = 0; i < lifeComponent.hearts.Length; i++)
            {
                if (lifeComponent.hitPoints > lifeComponent.maxHP)
                {
                   lifeComponent.hitPoints = lifeComponent.maxHP;
                }
                if (i < lifeComponent.hitPoints)
                {
                   lifeComponent.hearts[i].sprite = lifeComponent.fullHeart;
                }
                else
                {
                    lifeComponent.hearts[i].sprite = lifeComponent.emptyHeart;
                }
                if (i < lifeComponent.hitPoints)
                {
                    lifeComponent.hearts[i].enabled = true;
                }
                else
                {
                    lifeComponent.hearts[i].enabled = false;
                }
            }
            for (int i = 0; i < lifeComponent.livesDisplay.Length; i++)
            {
                if (i < lifeComponent.lives)
                {
                    lifeComponent.livesDisplay[i].enabled = true;
                }
                else
                {
                    lifeComponent.livesDisplay[i].enabled = false;
                }
            }
        }); 
    }
} 
