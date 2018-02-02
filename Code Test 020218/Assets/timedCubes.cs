using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timedCubes : MonoBehaviour
{
    [SerializeField]
    private Text dateTime;

    private bool spawnCubeOnce;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private List<GameObject> cubes;
    
    private void Update()
    {

        dateTime.text = DateTime.UtcNow.ToLongTimeString();

        if(DateTime.UtcNow.Second % 2 == 0 && !spawnCubeOnce)
        {
            GameObject cube = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            spawnCubeOnce = true;
            cubes.Add(cube);
        }

        if(DateTime.UtcNow.Second % 2 == 1)
        {
            spawnCubeOnce = false;
        }

        if(cubes.ToArray().Length > 10)
        {
            Destroy(cubes[0]);
            cubes.RemoveAt(0);
        }
    }
}
