using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
   
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
            CheckInput();
            Move();
            Death();
        }
        if(transform.position.y < -2f)
        {
            Gamemanager.instance.GameOver();
        }
            
       
    }

    void Move()
    {
       transform.position += transform.forward * moveSpeed *Time.deltaTime ;
        
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
          transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        else

        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Death()
    {
        if (transform.position.y < -2f)
        {
            
        }
    }
}





