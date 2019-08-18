using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCube : MonoBehaviour
{
    [SerializeField] private float minScale = 0.3f;
    [SerializeField] private float maxScale = 2f;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Color color = new Color(AudioPeer.getAudioBandBuffer(1), AudioPeer.getAudioBandBuffer(5), AudioPeer.getAudioBandBuffer(3));
        sprite.color = color;
        float scale = CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(4), minScale, maxScale);
        transform.localScale = new Vector3(1, scale, 1);
    }
}
