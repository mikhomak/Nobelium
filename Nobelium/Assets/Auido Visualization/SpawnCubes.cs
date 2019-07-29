using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{

    [SerializeField] private float maxScale = 1000f;
    [SerializeField] private GameObject cubePrefab;
    private GameObject[] sampleCubes = new GameObject[512];

    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject instanceCube = (GameObject)Instantiate(cubePrefab);
            instanceCube.transform.position = this.transform.position;
            instanceCube.transform.parent = this.transform;
            instanceCube.name = "SampleCube" + 1;
            instanceCube.transform.position = new Vector3(0.703125f * i, 0, 0);
            sampleCubes[i] = instanceCube;
        }
    }

    void Update()
    {
        for(int i = 0; i < 512; i++){
            if(sampleCubes != null)
            {
                sampleCubes[i].transform.localScale = new Vector2(10, AudioPeer.getSample(i) * maxScale);
            }
        }
    }
}
