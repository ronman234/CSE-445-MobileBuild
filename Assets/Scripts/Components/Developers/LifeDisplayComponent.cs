using UnityEngine;
using UnityEngine.UI;

public class LifeDisplayComponent : MonoBehaviour
{
    public int health; // Health of Entity
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
}

