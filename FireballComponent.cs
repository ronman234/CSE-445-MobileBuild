using UnityEngine;

public class FireballComponent : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public Vector2 targetDir;
    public Vector2 dir;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        //FindObjectOfType<AudioManager>().Play("FireballCast");
    }

    //Aims projectile towards players
    public void SetTargetDirection(Vector2 dir)
    {
        targetDir = dir;
    }

    //Destroys Projectile
    void DestroyProjectile()
    {
        //FindObjectOfType<AudioManager>.Stop("FireballCast");
        Destroy(gameObject);
    }
}

