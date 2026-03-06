using UnityEngine;

public class Collectble : MonoBehaviour
{
    [SerializeField] private AudioSource sf;
    [SerializeField] private AudioClip sfx;
    [SerializeField] private GameObject vfx;
    
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
       

