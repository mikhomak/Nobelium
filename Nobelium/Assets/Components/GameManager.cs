using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    GameObject player;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindGameObjectWithTag("player");
    }

    public Vector3 getPlayerPos(GameObject player)
    {
        return new Vector3(player.transform.position.x, player.transform.position.y, 0);
    }
}
