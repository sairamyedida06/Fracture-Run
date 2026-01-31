using UnityEngine;

public class Collectble : MonoBehaviour
{
    [SerializeField] private AudioSource sf;
    [SerializeField] private AudioClip sfx;
    [SerializeField] private GameObject vfx;
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
            
            Gamemanager.instance.score += 5;
            Instantiate(vfx,transform.position,vfx.transform.rotation) ;
            AudioSource.PlayClipAtPoint(sfx, transform.position);


            Destroy(gameObject);
        }
    }


}
       

