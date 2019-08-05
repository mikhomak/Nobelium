using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float musicScale = 15f;
    [SerializeField] private int direction = 1;
    [SerializeField] private float timeToChangeDirection = 2f;
    [SerializeField] private float timerToChangeDirection = 0f;

    private void Update()
    {
        if(AudioPeer.getBandBuffer(0) > 1)
        {
            if (timerToChangeDirection > timeToChangeDirection)
            {
                direction *= -1;
                timerToChangeDirection = 0f;
            }
        }
        timerToChangeDirection += Time.deltaTime;
        float scale = AudioPeer.getBandBuffer(6) * musicScale < 1 ? musicScale : AudioPeer.getBandBuffer(6) * musicScale;
        scale *= direction;
        transform.Rotate(Vector3.forward, Time.deltaTime * scale);
    }

}
