using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{
    [SerializeField] private static float[] freqBand = new float[8];
    [SerializeField] private static float[] samples = new float[512];
    private AudioSource audioSource;


    public static float getSample(int i) { return samples[i]; }
    public static float getFreqBands(int i) { return freqBand[i]; }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        getSpectrumAudioSource();
        updateFrequencyBrands();
    }

    private void getSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples,0,FFTWindow.Blackman);
    }

    private void updateFrequencyBrands()
    {
        int count = 0;
        for(int i =0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
                sampleCount += 2;
            for(int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;
            freqBand[i] = average * 10;
        }
    }

}
