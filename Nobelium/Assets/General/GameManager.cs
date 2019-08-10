using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private GameObject player;

    UnityEvent pauseEvent = new UnityEvent();
    UnityEvent resumeEvent = new UnityEvent();

    void Awake()
    {
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        findPlayer();
    }


    public void addListenerToMainEvents(UnityAction pauseAction, UnityAction resumeAction)
    {
        pauseEvent.AddListener(pauseAction);
        pauseEvent.AddListener(presumeAction);
    }

    private void pauseGame()
    {
        pauseEvent.Invoke();
    }

    private void findPlayer(){
        player = GameObject.FindGameObjectWithTag("player");

    }

    public Vector3 getPlayerPos(GameObject player)
    {
        return new Vector3(player.transform.position.x, player.transform.position.y, 0);
    }
}
