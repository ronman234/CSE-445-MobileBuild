using UnityEngine;

public class MovingPlatformComponent : MonoBehaviour
{
    public GameObject platform;
    public float moveSpeed;
    [HideInInspector]
    public Transform currentPoint;
    public Transform[] points;
    [HideInInspector]
    public int pointSelection;

}
