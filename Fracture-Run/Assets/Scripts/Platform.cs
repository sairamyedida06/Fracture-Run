using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject collectble;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCollectble();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Fall",0.2f);
        }
        
    }
    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }

    void SpawnCollectble()
    {
        int randomNumber = Random.Range(0, 15);
        Vector3 collectblePosition = transform.position;
        collectblePosition.y += .5f;

        if (randomNumber < 1)
        {
            GameObject collectbleInstance = Instantiate(collectble,collectblePosition,Quaternion.identity);
            collectbleInstance.transform.SetParent(gameObject.transform);
        }
    }
    
}
