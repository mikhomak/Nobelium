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
        EnemyFabric.instance.spawnEnemy();
    }


    public void addListenerToMainEvents(UnityAction pauseAction, UnityAction resumeAction) {
        Debug.Log("KSK" + pauseAction.Target);
        pauseEvent.AddListener(pauseAction);
        resumeEvent.AddListener(resumeAction);
    }

    public void pauseGame() {
        pauseEvent.Invoke();
    }

    public void resumeGame() {
        resumeEvent.Invoke();
    }

    public void gameOver() {
    }

    private void findPlayer() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public Vector3 getPlayerPos(GameObject player) {
        return new Vector3(player.transform.position.x, player.transform.position.y, 0);
    }
}