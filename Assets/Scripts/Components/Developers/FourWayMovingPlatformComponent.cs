using UnityEngine;

public class FourWayMovingPlatformComponent : MonoBehaviour
{
    //problem with disappearing platform resolved by setting z axis to -5 in Camera script in Main Camera

    public GameObject platform;
    public GameObject player;
    public float moveSpeed;
    [HideInInspector]
    public Transform currentPoint;
    public Transform[] points;
    public int pointSelection;
}
