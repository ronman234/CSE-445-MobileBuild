using Unity.Mathematics;
using Unity.Entities;
using UnityEngine;

public class MapSpawnSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((MapComponent map) =>
        {
            if ( map.MapMultiplier != 0 )
            {
                for ( int i = 1; i <= map.MapMultiplier; i++ )
                {
                    GameObject obj = map.RandomMapPrefabs[UnityEngine.Random.Range(0, map.RandomMapPrefabs.Length)];
                    GameObject.Instantiate(obj, new float3(0, i * map.MapHeight, 0), quaternion.identity);
                }

                map.MapMultiplier = 0;
            }
        });
    }
}
