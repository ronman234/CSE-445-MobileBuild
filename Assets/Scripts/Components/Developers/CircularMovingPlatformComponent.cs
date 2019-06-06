using UnityEngine;

public class CircularMovingPlatformComponent : MonoBehaviour
{
    public Transform Platform;

    public Transform Player;

    public float RotationRadius;
    public float AngularSpeed;   //set positive value for counter clockwise rotation and negative to go clockwise


    public float PosX;
    public float PosY;
    public float Angle;
}
