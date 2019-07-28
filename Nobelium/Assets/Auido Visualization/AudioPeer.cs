using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{

    [SerializeField] private static float[] samples = new float[512];
    private AudioSource audioSource;


    public static float getSample(int i) { return samples[i]; }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        getSpectrumAudioSource();
    }

    private void getSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples,0,FFTWindow.Blackman);
    }

}
