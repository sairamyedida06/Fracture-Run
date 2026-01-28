using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColourChange : MonoBehaviour
{
    public Color[] colours;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ColourChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ColourChange()
    {
        while (true)
        {
             int random = Random.Range(0,11);

            Camera.main.backgroundColor = colours[random];

            yield return new WaitForSeconds(8f);


        }
    }

}
