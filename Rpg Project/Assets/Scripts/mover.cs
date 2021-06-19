using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class mover : Fighter
{
    #region Variables Declarations
    //requirements
    protected BoxCollider2D _boxCollider;
     protected RaycastHit2D hit;
    protected Vector3 moveDelata;
    private Vector3 original_size;

    //inputs
     protected Vector2 moveDir;

    //movement
    protected float speed = 1f;
   public float xSpeed = 1f;
    public float ySpeed = 0.75f;


    #endregion

    #region Unity Methods
    //basic methods
    protected virtual void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        original_size = transform.localScale;
    }
    protected override void Update()
    {
       //Inputs();
        
    }



    protected virtual void UpdateMotor(Vector3 input1)
    {

        moveDir = input1;
        //SpriteFlipper();
        if (moveDir.x > 0)
        {
            transform.localScale = original_size;
        }
        else if (moveDir.x < 0)
        {
            transform.localScale = new Vector3(-original_size.x, original_size.y,original_size.z);
        }

        //add push direction if any
        moveDelata += pushDirection;

        //reduce the pushForce too so that the enemydoes not sit in the corner forever
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);



      //  moveDir.Normalize();//to counter diagonal movement

        ///we check weather we can move movedir.y*time.delta timnes distance at that particualr frame when we are pressing the ip
        ///1st argumnent-position to cast from,2nd arg - size of the collider,3rd arg - Angle
        ///4th arg Max distance to cast ,5th layermask which we want to know if the player collided with

        //this is for y direction
        hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, moveDir.y),
            Mathf.Abs(moveDir.y * Time.deltaTime), LayerMask.GetMask("Actors", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0f, moveDir.y * Time.deltaTime * ySpeed, 0f);
        }
        //this is for x direction
        hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(moveDir.x, 0f),
            Mathf.Abs(moveDir.x * Time.deltaTime), LayerMask.GetMask("Actors", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDir.x * Time.deltaTime * xSpeed, 0f, 0f);
        }

        //now this will initially will not move the player as it is colliding with itself as we are casting the box from player position and 
        //player is also on the same layer
        //so to avoid that go to physics and uncheck query start in collider,i.e it will ignore itself
       // Movement();
    }

    private void FixedUpdate()
    {

    }
    #endregion

    private void Inputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
       // moveDir = new Vector3(x, y);
    }


    
}
