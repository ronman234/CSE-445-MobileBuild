using System.Collections;
using Unity.Mathematics;
using Unity.Entities;
using UnityEngine;

public class MapComponent : MonoBehaviour
{
    public GameObject[] RandomMapPrefabs = new GameObject[10];
    public float MapHeight = 12.6f;
    public int MapMultiplier = 10;
}
