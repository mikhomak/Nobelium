using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{
    [SerializeField] private static float[] freqBand = new float[8];
    [SerializeField] private static float[] bandBuffer = new float[8];
    [SerializeField] private static float[] bufferDescrease = new float[8];
    [SerializeField] private static float[] samples = new float[512];
    private AudioSource audioSource;


    public static float getSample(int i) { return samples[i]; }
    public static float getFreqBands(int i) { return freqBand[i]; }
    public static float getBandBuffer(int i) { return bandBuffer[i]; }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        getSpectrumAudioSource();
        updateFrequencyBrands();
        updateBandBuffer();
        for (int i = 0; i < freqBand.Length; i++) 
            Debug.Log("Freq band " + i + " - "+ freqBand[i]);
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

    private void updateBandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if(freqBand[i] > bandBuffer[i])
            {
                bandBuffer[i] = freqBand[i];
                bufferDescrease[i] = 0.005f;
            }
            if (freqBand[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDescrease[i];
                bufferDescrease[i] *= 1.2f;

            }
        }
    }

}
