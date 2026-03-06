using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;


    [Header("Movement")]
    public float baseMoveSpeed = 4f;
    [HideInInspector] public float currentMoveSpeed;

    bool tapTouch = true;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMoveSpeed = baseMoveSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.instance.gameStarted)
        {
            CheckInput();
            Move();
        
        }
        if(transform.position.y < -2f)
        {
            Gamemanager.instance.GameOver();
        }
            
       
    }

    void Move()
    {
       transform.position += transform.forward * currentMoveSpeed * Time.deltaTime ;
       
        
    }

    void CheckInput()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }


    }

    void ChangeDirection()
    {
        if (tapTouch)
        {
            tapTouch = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        else if(!tapTouch)

        {
            tapTouch = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}





