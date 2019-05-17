using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public bool isGrounded;
    public bool jumpedOnBat;
    public bool landedOnPlayer;
    public RaycastHit2D hitLeftFoot, hitLeftHeel, hitRightFoot, hitRightHeel;
}
