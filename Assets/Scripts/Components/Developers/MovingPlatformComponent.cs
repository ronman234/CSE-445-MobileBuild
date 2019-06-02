using UnityEngine;

public class MovingPlatformComponent : MonoBehaviour
{
    public Transform floatingplatform;

    public GameObject player; //allows player to be parent to platform

    public float leftLengthDistance;
    public float rightLengthDistance;
    public float speed;

    [HideInInspector]
    public Vector3 startPos;

    public bool isVertical;   //checks to see if platform is moving vertically or horizontally
}
