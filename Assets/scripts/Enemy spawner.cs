using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Az ellenség prefabok tömbje
    public float spawnInterval = 2f; // Idõköz a spawnok között
    public float spawnHeightOffset = 2f; // Mennyivel spawnoljon a kamera felett

    public GameObject healPickupPrefab; // A gyógyító tárgy prefabja
    public float healSpawnInterval = 10f; // Idõköz a gyógyító tárgy spawn között (ritkább)
    private float healSpawnTimer;

    private Camera mainCamera; // Referencia a fõ kamerára
    private float screenWidthWorldUnits; // A képernyõ szélessége világ egységben
    private float timer;

    void Start()
    {
        // Kamera referenciájának beállítása
        mainCamera = Camera.main;

        // Képernyõ szélességének meghatározása világ egységben
        screenWidthWorldUnits = mainCamera.orthographicSize * mainCamera.aspect * 2;
    }

    void Update()
    {
        //enemy spawnolás
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }

        // Gyógyító tárgy spawn idõzítõ
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
        // Véletlenszerû X pozíció a kamera szélességi tartományában
        float randomX = Random.Range(-screenWidthWorldUnits / 2, screenWidthWorldUnits / 2);

        // Véletlenszerû ellenség kiválasztása
        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        // Spawn pozíció meghatározása
        Vector3 spawnPosition = new Vector3(randomX, mainCamera.transform.position.y + spawnHeightOffset, 0);

        // Véletlenszerû ellenség létrehozása
        Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }

    void SpawnHealPickup()
    {
        // Véletlenszerû X pozíció a kamera szélességi tartományában
        float randomX = Random.Range(-screenWidthWorldUnits / 2, screenWidthWorldUnits / 2);

        // Spawn pozíció meghatározása
        Vector3 spawnPosition = new Vector3(randomX, mainCamera.transform.position.y + spawnHeightOffset, 0);

        // Gyógyító tárgy létrehozása
        Instantiate(healPickupPrefab, spawnPosition, Quaternion.identity);
    }
}
