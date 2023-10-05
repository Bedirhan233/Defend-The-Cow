using UnityEngine;

//This script is a clean powerful solution to a top-down movement player
public class Movement : MonoBehaviour
{
    //Public variables that wer can edit in the editor
    public float maxSpeed = 5; //Our max speed
    public float acceleration = 20; //How fast we accelerate
    public float deacceleration = 4; //brake power

    //Jump variables
    public float jumpPower = 8;
    public float groundCheckDistance = 0.1f;
    bool onGround = true;
    bool onWallRight = true; 
    bool onWallLeft = true; 
    float downCheckLenght;
    float rightSideLength;
    float leftSideLength;
    int maxJumps = 1;
    int currentJumps = 0;

    bool onAir;

    float velocityX; //Our current velocity

    Rigidbody2D rb2D; //Ref to our rigidbody

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rb2D = GetComponent<Rigidbody2D>(); //assign our ref.

        var collider = GetComponent<Collider2D>();
        downCheckLenght = collider.bounds.size.y + 0.1f;
        rightSideLength = collider.bounds.size.x + 0.1f;
        leftSideLength = -collider.bounds.size.x + - 0.1f;
    }

    void Update()
    {
        MovementX();

        if (Input.GetButtonDown("Jump") && onGround && currentJumps < maxJumps)
        {
            currentJumps = 1;
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
            
        }

        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.25f);
            currentJumps = 0;
        }

        onGround = Physics2D.Raycast(transform.position, Vector2.down, downCheckLenght);
        onWallRight = Physics2D.Raycast(transform.position, Vector2.right, rightSideLength);
        onWallLeft = Physics2D.Raycast(transform.position, Vector2.left, leftSideLength);

        

        if(onWallRight) 
        {
            Debug.Log("Right");
            currentJumps = 0;

        }

        if(onWallLeft) 
        {
            Debug.Log("Left");
            currentJumps = 0;

        }


        if (rb2D.velocity.y < 0)
        {
            rb2D.gravityScale = 4;
        }
        else
        {
            rb2D.gravityScale = 1;
        }
    }

    private void MovementX()
    {
        //Get the raw input
        float directionX = Input.GetAxisRaw("Horizontal");

        //add our input to our velocity
        //This provides accelleration +10m/s/s
        velocityX += directionX * acceleration * Time.deltaTime;

        //Check our max speed, if our magnitude is faster them max speed
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        //If we have zero input from the player
        if (directionX == 0 || (directionX < 0 == velocityX > 0))
        {
            //Reduce our speed based on how fast we are going
            //A value of 0.9 would remove 10% or our speed
            velocityX *= 1 - deacceleration * Time.deltaTime;
        }

        //Now we can move with the rigidbody and we get propper collisions
        rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
    }
}