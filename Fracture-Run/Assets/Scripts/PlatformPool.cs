using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    
    public GameObject platformPrefab;

   
    public int poolSize = 20;

    
    private Queue<GameObject> availablePlatforms;

   
    private int activePlatformCount = 0;

    
    void Awake()
    {
        availablePlatforms = new Queue<GameObject>();

        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject p = Instantiate(platformPrefab);
            p.SetActive(false);
            availablePlatforms.Enqueue(p);
        }
    }

   
    public GameObject GetPlatform()
    {
        if (availablePlatforms.Count == 0)
        {
            return null; 
        }

        
        GameObject platform = availablePlatforms.Dequeue();
        activePlatformCount++;
        return platform;
    }

  
    public void ReturnPlatform(GameObject platform)
    {
        
        availablePlatforms.Enqueue(platform);
        activePlatformCount--;
    }

    
    public int GetActiveCount()
    {
        return activePlatformCount;
    }

    
    public int GetFreeCount()
    {
        return availablePlatforms.Count;
    }
}
