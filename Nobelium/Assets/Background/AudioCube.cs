using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCube : MonoBehaviour
{
    [SerializeField] private float minScale = 0.3f;
    [SerializeField] private float maxScale = 2f;
    [SerializeField] private float red;
    [SerializeField] private float green;
    [SerializeField] private float blue;
    [SerializeField] private Color cubeColour;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        red = CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(1), 0.4f, 0.9f);
        green = CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(5), 0.4f, 0.9f);
        blue = CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(3), 0.4f, 0.9f);
        cubeColour = new Color(red, green, blue);
    }

    private void FixedUpdate()
    {
        if (AudioPeer.getAudioBandBuffer(5) > 0.6f)
        {
            cubeColour = CommonMethods.GetNextPseudoRandomColor(cubeColour);
            sprite.color = cubeColour;
        }
        float scale = CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(4), minScale, maxScale);
        transform.localScale = new Vector3(1, scale, 1);
    }
}
