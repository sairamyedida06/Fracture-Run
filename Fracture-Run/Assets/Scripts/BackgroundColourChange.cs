using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColourChange : MonoBehaviour
{
    
    public Material[] skyboxes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SkyboxChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SkyboxChange()
    {
        while (true)
        {
            int random = Random.Range(0, skyboxes.Length);

            RenderSettings.skybox = skyboxes[random];
            DynamicGI.UpdateEnvironment(); 

            yield return new WaitForSeconds(8f);
        }
    }


}
