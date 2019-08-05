using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCube : MonoBehaviour
{
    [SerializeField] private float transformScale = 2;

    private void Update()
    {
        float scale = AudioPeer.getBandBuffer(4) > 2.2 ? 2.2f: AudioPeer.getBandBuffer(5);
        scale = scale < 0.7f ? 0.7f : scale;
        transform.localScale = new Vector3(1, scale, 1);
    }
}
