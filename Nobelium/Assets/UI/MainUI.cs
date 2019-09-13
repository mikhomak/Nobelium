using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public static MainUI instnace = null;

    private void Awake()
    {
        if (instnace == null)
            instnace = this;
        else if (instnace != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }


    public void pause() {
        GameManager.instance.pauseGame();
    }

    public void resume() {
        GameManager.instance.resumeGame();
    }


}
