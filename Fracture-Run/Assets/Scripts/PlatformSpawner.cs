using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    

    public Transform lastPlatform;
    Vector3 lastposition;
    Vector3 newPosition;
    bool stop;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastposition = lastPlatform.position;
        StartCoroutine(SpawnPlatform());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPlatform()
    {
        while (!stop)
        {
            Position();

            Instantiate(platform, newPosition, Quaternion.identity);

            lastposition = newPosition;
            yield return new WaitForSeconds(0.2f);
        }
    }

    void Position()
    {
        newPosition = lastposition;
        int random = Random.Range(0, 2);

        if(random > 0)
        {
            newPosition.x += 1;
        }
        else
        {
            newPosition.z += 1;
        }
    }
}
