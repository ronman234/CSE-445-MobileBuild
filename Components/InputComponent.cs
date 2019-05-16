using UnityEngine;

public class InputComponent : MonoBehaviour
{
    // Horizontal direction of Player
    public float Movement;  // horizontal direction of player
    public bool Jump;       // whether the player is jumping or grounded
    public bool Down;       // allows movement down certain platforms

    //Touch key features
    public bool RightTouchKey;
    public bool LeftTouchKey;
    public bool MiddleTouchKey;

}
