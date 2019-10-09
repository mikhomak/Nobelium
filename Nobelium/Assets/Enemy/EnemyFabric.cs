using UnityEngine;

public class EnemyFabric : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private BoxPoints boxPoints;
    [SerializeField] private GameObject cubePhase1;
    [SerializeField] private GameObject cubePhase2;
    [SerializeField] private int currentPhase;
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


    public void changeCurrentPhase(int phase) {
        currentPhase = phase;
    }

    public void spawnCubes(Vector2 position, Quaternion rotation) {
        switch (currentPhase) {
            case 1:
                Instantiate(cubePhase1, position, rotation);
                break;
            case 2:
                Instantiate(cubePhase2, position, rotation);
                break;
        }
    }

    private void spawn(GameObject objectToSpawn) {
        Instantiate(objectToSpawn);
    }
}


