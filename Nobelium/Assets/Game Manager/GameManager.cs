﻿using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject enemy;

    public static GameManager instance = null;
    private GameObject player;

    private readonly UnityEvent pauseEvent = new UnityEvent();
    private readonly UnityEvent resumeEvent = new UnityEvent();


    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    private void Start() {
        EnemyFabric.instance.spawnEnemy();
    }

    public void addListenerToMainEvents(UnityAction pauseAction, UnityAction resumeAction) {
        pauseEvent.AddListener(pauseAction);
        resumeEvent.AddListener(resumeAction);
    }

    public void pauseGame() {
        AudioPeer.instance.pauseSong();
        Time.timeScale = 0;
        // pauseEvent.Invoke();
    }

    public void resumeGame() {
        Time.timeScale = 1;
        AudioPeer.instance.resumeSong();
        //resumeEvent.Invoke();
    }

    public void gameOver() {
    }


}