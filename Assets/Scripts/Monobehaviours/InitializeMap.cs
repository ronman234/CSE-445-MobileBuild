using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InitializeMap : MonoBehaviour
{
    public GameObject[] randomMapPrefabs = new GameObject[10];
    public float mapHeight = 12.58f;
    public int mapMultiplier = 10;

    void Awake()
    {
        /*
        int[] totalMaps = new int[mapMultiplier];
        
        foreach ( int mapCount in totalMaps )
        {
            Debug.Log("I am working!");
            GameObject obj = randomMapPrefabs[UnityEngine.Random.Range(0, randomMapPrefabs.Length)];
            GameObject.Instantiate(obj, new float3(0, mapCount * mapHeight + mapHeight , 0), quaternion.identity);
        }
        */

        for ( int i = 1; i <= mapMultiplier; i++ )
        {
            GameObject obj = randomMapPrefabs[UnityEngine.Random.Range(0, randomMapPrefabs.Length)];
            GameObject.Instantiate(obj, new float3(0, i * mapHeight, 0), quaternion.identity);
        }

        Destroy(gameObject);
    }
}
