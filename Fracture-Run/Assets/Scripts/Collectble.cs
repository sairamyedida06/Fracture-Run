using UnityEngine;

public class Collectble : MonoBehaviour
{
    public AudioSource sf;
    public AudioClip sfx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Gamemanager.instance.score +=10 ;
            AudioSource.PlayClipAtPoint(sfx, transform.position);


            Destroy(gameObject);
        }
    }


}
       

