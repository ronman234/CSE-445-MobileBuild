using Unity.Entities;
using UnityEngine;


public class LifeDisplaySystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((LifeDisplayComponent lifeDispalyComponent) =>
        {
            //Displays Heart System
            for (int i = 0; i < lifeDispalyComponent.hearts.Length; i++)
            {
                if (lifeDispalyComponent.health > lifeDispalyComponent.numOfHearts)
                {
                    lifeDispalyComponent.health = lifeDispalyComponent.numOfHearts;
                }
                if (i < lifeDispalyComponent.health)
                {
                    lifeDispalyComponent.hearts[i].sprite = lifeDispalyComponent.fullHeart;
                }
                else
                {
                    lifeDispalyComponent.hearts[i].sprite = lifeDispalyComponent.emptyHeart;
                }
                if (i < lifeDispalyComponent.numOfHearts)
                {
                    lifeDispalyComponent.hearts[i].enabled = true;
                }
                else
                {
                    lifeDispalyComponent.hearts[i].enabled = false;
                }
             }
        });
    }
}
