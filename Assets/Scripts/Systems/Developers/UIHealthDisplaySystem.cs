using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class UIHealthDisplaySystem : ComponentSystem
{
   public int hp;

    protected override void OnUpdate()
    {   
        Entities.ForEach((TagPlayerComponent tag, HealthComponent health) =>
        {
            hp = health.currentHealth;
        });

        Entities.ForEach((PlayerUIHealthComponent UI) =>
        {
            int health = hp;

            switch (health)
            {
                case 3:
                    UI.heart1.gameObject.SetActive(true);
                    UI.heart2.gameObject.SetActive(true);
                    UI.heart3.gameObject.SetActive(true);
                    break;
                case 2:
                    UI.heart1.gameObject.SetActive(true);
                    UI.heart2.gameObject.SetActive(true);
                    UI.heart3.gameObject.SetActive(false);
                    break;
                case 1:
                    UI.heart1.gameObject.SetActive(true);
                    UI.heart2.gameObject.SetActive(false);
                    UI.heart3.gameObject.SetActive(false);
                    break;
                case 0:
                    UI.heart1.gameObject.SetActive(false);
                    UI.heart2.gameObject.SetActive(false);
                    UI.heart3.gameObject.SetActive(false);
                    break;
            }
        });
    }
} 
