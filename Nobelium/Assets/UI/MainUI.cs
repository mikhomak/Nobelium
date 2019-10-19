using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public static MainUI instance = null;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }


    public void pause() {
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        GameManager.instance.pauseGame();
    }

    public void resume() {
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        GameManager.instance.resumeGame();
    }


}
