using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCube : MonoBehaviour
{
    [SerializeField] private int band;
    [SerializeField] private float startScale;
    [SerializeField] private float scaleMultipler;


    private void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.getBandBuffer(band) * scaleMultipler) + startScale, transform.localScale.z);
    }
}
