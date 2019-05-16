using UnityEngine;

public class MoveSpeedComponent : MonoBehaviour
{
    public float moveSpeed; //movement speed
    public float jumpSpeed; //Speed of the jump

    public bool isGrounded; //checks to see if player is grounded
    public float groundCheckRadius; //radius of the ground check 
    public LayerMask Ground;
    public Transform groundCheck;

    [HideInInspector]
    public float extraJumpsValue; //stores value of how many addition jumps for player
    public float extraJumps; //sets values for max amount of jumps
  
}
