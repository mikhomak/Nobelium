using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{

    [SerializeField] private float[] samples = new float[512];
    private AudioSource audioSource;

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
