using Unity.Entities;

public class UILivesDisplaySystem : ComponentSystem
{
    public int life;

    protected override void OnUpdate()
    {
        Entities.ForEach((TagPlayerComponent tag, LivesComponent health) =>
        {
            life = health.lives;
        });

        Entities.ForEach((PlayerUILivesComponent UI) =>
        {
            int health = life;

            switch (health) //displays lives UI
            {
                case 3: //displays all 3 lives
                    UI.live1.gameObject.SetActive(true);
                    UI.live2.gameObject.SetActive(true);
                    UI.live3.gameObject.SetActive(true);
                    break;
                case 2: //displays 2 of 3 lives
                    UI.live1.gameObject.SetActive(true);
                    UI.live2.gameObject.SetActive(true);
                    UI.live3.gameObject.SetActive(false);
                    break;
                case 1: //displays 1 of 3 hearts
                    UI.live1.gameObject.SetActive(true);
                    UI.live2.gameObject.SetActive(false);
                    UI.live3.gameObject.SetActive(false);
                    break;
                case 0: //displays 0 of 3 hearts
                    UI.live1.gameObject.SetActive(false);
                    UI.live2.gameObject.SetActive(false);
                    UI.live3.gameObject.SetActive(false);
                    break;
            }
        });
    }
}
