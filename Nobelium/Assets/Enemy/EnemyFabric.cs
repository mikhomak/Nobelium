using UnityEngine;

public class EnemyFabric : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private BoxPoints boxPoints;
    public static EnemyFabric instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void spawnEnemy() {
        GameObject enemyGO = Instantiate(enemyPrefab);
        enemyGO.GetComponent<IEnemy>().setBoxPoints(boxPoints);
    }


    private void spawn(GameObject objectToSpawn) {
        Instantiate(objectToSpawn);
    }
}