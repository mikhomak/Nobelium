﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour {
    [SerializeField] private static int maxBands = 8;
    [SerializeField] private static float BUFFER_INCREASE = 0.005f;
    [SerializeField] private static float BUFFER_DESCREASE = 1.2f;
    [SerializeField] private static float[] audioBand = new float[maxBands];
    [SerializeField] private static float[] audioBandBuffer = new float[maxBands];
    [SerializeField] private static float[] freqBandHighest = new float[maxBands];
    [SerializeField] private static float[] freqBand = new float[maxBands];
    [SerializeField] private static float[] bandBuffer = new float[maxBands];
    [SerializeField] private static float[] bufferDescrease = new float[maxBands];
    [SerializeField] private static float[] samples = new float[512];
    private AudioSource audioSource;
    public static AudioPeer instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public static float getSample(int i) {
        return float.IsNaN(samples[i]) ? 0 : samples[i];
    }
    
    public static float getAudioBandBuffer(int i) {
        return float.IsNaN(audioBandBuffer[i]) ? 0 : audioBandBuffer[i];
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        getSpectrumAudioSource();
        updateFrequencyBrands();
        updateBandBuffer();
        updateAudioBands();
    }

    private void getSpectrumAudioSource() {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    private void updateFrequencyBrands() {
        int count = 0;
        for (int i = 0; i < maxBands; i++) {
            float average = 0;
            int sampleCount = (int) Mathf.Pow(2, i) * 2;
            if (i == 7)
                sampleCount += 2;
            for (int j = 0; j < sampleCount; j++) {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;
            freqBand[i] = average * 10;
        }
    }

    private void updateBandBuffer() {
        for (int i = 0; i < maxBands; i++) {
            if (freqBand[i] > bandBuffer[i]) {
                bandBuffer[i] = freqBand[i];
                bufferDescrease[i] = BUFFER_INCREASE;
            }

            if (freqBand[i] < bandBuffer[i]) {
                bandBuffer[i] -= bufferDescrease[i];
                bufferDescrease[i] *= BUFFER_DESCREASE;
            }
        }
    }


    private void updateAudioBands() {
        for (int i = 0; i < maxBands; i++) {
            if (freqBand[i] > freqBandHighest[i]) {
                freqBandHighest[i] = freqBand[i];
            }

            audioBand[i] = (freqBand[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    public void pauseSong() {
        audioSource.Stop();
    }

    public void resumeSong() {
        audioSource.UnPause();        
    }
}