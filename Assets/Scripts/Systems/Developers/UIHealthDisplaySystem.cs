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

            switch (health) //displays health UI
            {
                case 3: //displays all 3 hearts
                    UI.heart1.gameObject.SetActive(true);
                    UI.heart2.gameObject.SetActive(true);
                    UI.heart3.gameObject.SetActive(true);
                    break;
                case 2: //displays 2 of 3 hearts
                    UI.heart1.gameObject.SetActive(true);
                    UI.heart2.gameObject.SetActive(true);
                    UI.heart3.gameObject.SetActive(false);
                    break;
                case 1: //displays 1 0f 3 hearts
                    UI.heart1.gameObject.SetActive(true);
                    UI.heart2.gameObject.SetActive(false);
                    UI.heart3.gameObject.SetActive(false);
                    break;
                case 0: // displays 0 of 3 hearts
                    UI.heart1.gameObject.SetActive(false);
                    UI.heart2.gameObject.SetActive(false);
                    UI.heart3.gameObject.SetActive(false);
                    break;
            }
        });
    }
} 
