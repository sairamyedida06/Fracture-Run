using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    private string playerTag = "Player";

    public float fallDelay = 0.1f;
    public float fallDistanceBeforeHide = 5f;

    private Rigidbody rb;
    private Vector3 startPosition;
    private bool isFalling = false;

    private PlatformPool pool;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    void OnEnable()
    {
        
        if (pool == null)
        {
            pool = FindAnyObjectByType<PlatformPool>();

            if (pool == null)
            {
                Debug.LogError("[Platform] Could not find PlatformPool in the scene!");
                return;
            }
        }

        
        isFalling = false;
        rb.useGravity = false;
        rb.isKinematic = true;
        startPosition = transform.position;
    }

    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag) && !isFalling)
        {
            Invoke("StartFalling", fallDelay);
        }
    }

    
    void StartFalling()
    {
        isFalling = true;
        rb.isKinematic = false;
        rb.useGravity = true;
    }

  
    void Update()
    {
        if (!isFalling) return;

       
        if (pool == null) return;

        float distanceFallen = startPosition.y - transform.position.y;

        if (distanceFallen >= fallDistanceBeforeHide)
        {
            CancelInvoke();
            pool.ReturnPlatform(gameObject);
            gameObject.SetActive(false);
        }
    }
}