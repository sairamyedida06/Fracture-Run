using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    bool movingLeft = true;
    bool firstTouch = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.instance.gameStarted)
        {
            
        }
            
       
    }

    private void FixedUpdate()
    {

        if (Gamemanager.instance.gameStarted)
        {
            CheckInput();
            Move();
            Death();
        }
        
        
    }

    void Move()
    {
        rb.linearVelocity = new Vector3(transform.forward.x * moveSpeed,rb.linearVelocity.y, transform.forward.z * moveSpeed);
        
    }

    void CheckInput()
    {
        if (firstTouch)
        {
            firstTouch = false;
            return;
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }


    }

    void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;
           rb.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        else

        {
            movingLeft = true;
            rb.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Death()
    {
        if (rb.transform.position.y < -2f)
        {
            
        }
    }
}





