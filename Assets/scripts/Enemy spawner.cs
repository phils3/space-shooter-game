using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Az ellens�g prefabok t�mbje
    public float spawnInterval = 2f; // Id�k�z a spawnok k�z�tt
    public float spawnHeightOffset = 2f; // Mennyivel spawnoljon a kamera felett

    public GameObject healPickupPrefab; // A gy�gy�t� t�rgy prefabja
    public float healSpawnInterval = 10f; // Id�k�z a gy�gy�t� t�rgy spawn k�z�tt (ritk�bb)
    private float healSpawnTimer;

    private Camera mainCamera; // Referencia a f� kamer�ra
    private float screenWidthWorldUnits; // A k�perny� sz�less�ge vil�g egys�gben
    private float timer;

    void Start()
    {
        // Kamera referenci�j�nak be�ll�t�sa
        mainCamera = Camera.main;

        // K�perny� sz�less�g�nek meghat�roz�sa vil�g egys�gben
        screenWidthWorldUnits = mainCamera.orthographicSize * mainCamera.aspect * 2;
    }

    void Update()
    {
        //enemy spawnol�s
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }

        // Gy�gy�t� t�rgy spawn id�z�t�
        healSpawnTimer += Time.deltaTime;
        if (healSpawnTimer >= healSpawnInterval)
        {
            Debug.Log("heal spawn");
            SpawnHealPickup();
            healSpawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // V�letlenszer� X poz�ci� a kamera sz�less�gi tartom�ny�ban
        float randomX = Random.Range(-screenWidthWorldUnits / 2, screenWidthWorldUnits / 2);

        // V�letlenszer� ellens�g kiv�laszt�sa
        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        // Spawn poz�ci� meghat�roz�sa
        Vector3 spawnPosition = new Vector3(randomX, mainCamera.transform.position.y + spawnHeightOffset, 0);

        // V�letlenszer� ellens�g l�trehoz�sa
        Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }

    void SpawnHealPickup()
    {
        // V�letlenszer� X poz�ci� a kamera sz�less�gi tartom�ny�ban
        float randomX = Random.Range(-screenWidthWorldUnits / 2, screenWidthWorldUnits / 2);

        // Spawn poz�ci� meghat�roz�sa
        Vector3 spawnPosition = new Vector3(randomX, mainCamera.transform.position.y + spawnHeightOffset, 0);

        // Gy�gy�t� t�rgy l�trehoz�sa
        Instantiate(healPickupPrefab, spawnPosition, Quaternion.identity);
    }
}
