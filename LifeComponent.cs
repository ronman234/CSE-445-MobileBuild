using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeComponent : MonoBehaviour
{
    public int maxHP;
    public int hitPoints;
    public int lives;
    public float timeToDestroy;
    public bool player1Died;
    public bool player2Died;
    public Transform player1, player2, entity;
    public float timerDmg;

    public Image[] hearts, livesDisplay;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        hitPoints = maxHP;
        timerDmg = 0f;
    }

    //Establishes Hitpoint
    public int HitPoints
    {
        get { return hitPoints; }
        set
        {
            hitPoints += value;
            if (hitPoints > maxHP)
            {
                hitPoints = maxHP;
            }
        }

    }

    //Removes hitpoints 
    public void removeHitPoints(int i)
    {
        if (timerDmg > 1f)
        {
            hitPoints -= i;
            timerDmg = 0;
        }

    }

    //Death script for player 1 and 2
    IEnumerator Death()
    {
        yield return new WaitForSeconds(timeToDestroy);

        if (gameObject.tag == "Player")
        {
            --lives;
            if (lives <= 0)
            {
                hearts[0].enabled = false;
                hearts[1].enabled = false;
                hearts[2].enabled = false;

                livesDisplay[0].enabled = false;
                Destroy(gameObject);
            }
            else
            {
                hitPoints = maxHP;

                if (gameObject.transform == player1)
                {
                    player1Died = true;

                    if (player2 == null)
                    {
                        entity = player1;
                    }
                    else
                    {
                        entity = player2;
                    }
                }
                else
                {
                    player2Died = true;

                    if (player1 == null)
                    {
                        entity = player2;
                    }
                    else
                    {
                        entity = player1;
                    }
                }
                // FindSpawn(entity);
            }
        }
        else
        {
            if (gameObject.tag == "Wizard")
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }

    //Death initiated
    void FixedUpdate()
    {
        if (hitPoints <= 0)
        {
            StartCoroutine(Death());
        }
    }
}
