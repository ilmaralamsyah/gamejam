using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }


    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float dashCooldown = 2f;

    private bool isWalking;
    private Vector2 moveDir;
    private Rigidbody2D rb;
    private float lastHorizontalVector;
    private float lastVerticalVector;
    private float dashCounter;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one instance");
        }
        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameInput.OnFire += GameInput_OnFire;
        gameInput.OnDash += GameInput_OnDash;
    }

    private void Update()
    {
        dashCooldown += Time.deltaTime;
        HandleInput();
    }

    private void FixedUpdate()
    {
        ProcessMovement();
    }

    private void GameInput_OnDash(object sender, System.EventArgs e)
    {
        if(dashCounter > dashCooldown)
        {
            dashCounter = 0f;
            //dash
        }

        //dash
    }

    private void GameInput_OnFire(object sender, System.EventArgs e)
    {
        //firing
    }


    private void HandleInput()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        moveDir = new Vector2(inputVector.x, inputVector.y);

        isWalking = moveDir != Vector2.zero;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
        }
        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
        }
    }

    private void ProcessMovement()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public Vector2 MoveVector()
    {
        return moveDir;
    }

    public float GetLastXVector()
    {
        return lastHorizontalVector;
        
    }
}
