using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float musicScale = 15f;
    [SerializeField] private int direction = 1;
    [SerializeField] private float timeToChangeDirection = 2f;
    [SerializeField] private float timerToChangeDirection = 0f;
    [SerializeField] private float minSpeed = 10f;
    [SerializeField] private float maxSpeed = 60f;

    private void Update()
    {
        if(AudioPeer.getAudioBandBuffer(0) > 0.3f)
        {
            if (timerToChangeDirection > timeToChangeDirection)
            {
                direction *= -1;
                timerToChangeDirection = 0f;
            }
        }
        timerToChangeDirection += Time.deltaTime;
        float scale = CommonMethods.getValueInRange(AudioPeer.getAudioBandBuffer(6), minSpeed, maxSpeed);
        scale *= direction;
        transform.Rotate(Vector3.forward, Time.deltaTime * scale);
    }

}
