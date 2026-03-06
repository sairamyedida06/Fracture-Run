using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private PlatformPool pool;

    public Transform startPlatform;
    public float spawnInterval = 0.3f;
    public int maxActivePlatforms = 15;

    private Vector3 lastSpawnPosition;
    private Vector3 nextSpawnPosition;
    private bool stop = false;

  
    void Start()
    {
       
        pool = GetComponent<PlatformPool>();

        
        if (pool == null)
        {
            return;
        }

        if (startPlatform == null)
        {
            return;
        }

        lastSpawnPosition = startPlatform.position;
        StartCoroutine(SpawnLoop());
    }

    
    IEnumerator SpawnLoop()
    {
        while (!stop)
        {
            if (pool.GetActiveCount() < maxActivePlatforms)
            {
                GameObject freePlatform = pool.GetPlatform();

                while (freePlatform == null)
                {
                    yield return null;
                    freePlatform = pool.GetPlatform();
                }

                CalculateNextPosition();

                freePlatform.transform.position = nextSpawnPosition;
                freePlatform.transform.rotation = Quaternion.identity;
                freePlatform.SetActive(true);

                lastSpawnPosition = nextSpawnPosition;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    
    void CalculateNextPosition()
    {
        nextSpawnPosition = lastSpawnPosition;

        int randomDirection = Random.Range(0, 20);

        if (randomDirection > 12)

            nextSpawnPosition.x += 1;

        else
            nextSpawnPosition.z += 1;
    }
}