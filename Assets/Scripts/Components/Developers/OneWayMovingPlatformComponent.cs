using UnityEngine;

public class OneWayMovingPlatformComponent : MonoBehaviour
{
    public Transform floatingplatform;

    public GameObject player; //allows player to be parent to platform

    public float negativeLengthDistance;
    public float positiveLengthDistance;
    public float speed;

    [HideInInspector]
    public Vector2 startPos;

    public bool isVertical;   //checks to see if platform is moving vertically or horizontally
}
