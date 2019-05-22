using UnityEngine;

public class MoveSpeedComponent : MonoBehaviour
{
    public float moveSpeed; //movement speed
    public float jumpSpeed; //Speed of the jump

    public bool isGrounded; //checks to see if player is grounded
    public float groundCheckRadius; //radius of the ground check 
    public LayerMask Ground;  //sets layer of gameobject to be the ground
    public Transform groundCheck; //connects to a empty gameobject that is parented to the player at the base of their feet
    
    [HideInInspector]
    public float extraJumpsValue; //stores value of how many addition jumps for player
    public float extraJumps; //User sets values for max amount of jumps
  
}
