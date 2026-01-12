using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform playerTransform;
    public float spawnDistance = 15f;
    public float Distance = 1.5f; 

    private Vector3 nextSpawnPoint;
    private Quaternion nextRotation = Quaternion.identity;
    private int stepCounter = 0;
    private bool turningRight = true;
    private int currentTileCount = 0;
    public int maxTilesOnScreen = 40;
    public GameObject fishPrefab; // 在Inspector里拖入鱼的预制体
    public float fishSpawnChance = 0.5f;

    void Start()
    {
        GameObject startPlatform = GameObject.FindWithTag("StartPlatform");
        if (startPlatform != null)
        {
            nextSpawnPoint = startPlatform.transform.position;
            nextSpawnPoint += nextRotation * new Vector3(0, 0, Distance*2); 
        }
        for (int i = 0; i < 5; i++) SpawnTile();
    }

    void Update()
    {
        if (playerTransform == null) return;
        float dist = Vector3.Distance(playerTransform.position, nextSpawnPoint);
        if (dist < spawnDistance && currentTileCount < maxTilesOnScreen)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        GameObject tempTile = Instantiate(tilePrefab, nextSpawnPoint, nextRotation);
        currentTileCount++;
        if (Random.value < fishSpawnChance)
        {
        GameObject fish = Instantiate(fishPrefab, nextSpawnPoint, Quaternion.identity);
        
        FishJump fishScript = fish.GetComponent<FishJump>();
        if (fishScript != null)
        {
            fishScript.SetupJump(nextSpawnPoint, nextRotation);
        }
        }
        
        if (stepCounter >= 4)
        {
            stepCounter = 0; 
            float angle = turningRight ? 90f : -90f;
            nextRotation *= Quaternion.Euler(0, angle, 0);
            turningRight = !turningRight;
        }

        Vector3 edgePoint = nextSpawnPoint + (nextRotation * new Vector3(0, 0, Distance));
        nextSpawnPoint = edgePoint + (nextRotation * new Vector3(0, 0, Distance));
        stepCounter++;
        
    }
}