using Unity.VisualScripting;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{

    public Transform target;
    public float followSeed;

    Vector3 distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y>=0)
        {
            Follow();
        }


            
       
    }

    void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3  targetpos = target.position - distance;

        transform.position = Vector3.Lerp(currentPos, targetpos, followSeed * Time.deltaTime);
        

    }
}
