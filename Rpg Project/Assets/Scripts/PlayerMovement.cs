using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Variables Declarations
    //requirements
    private BoxCollider2D _boxCollider;
    RaycastHit2D hit;

    //inputs
    Vector2 moveDir;

    //movement
    private float speed = 1f;

    #endregion

    #region Unity Methods
    //basic methods
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        Inputs();
        SpriteFlipper();
        Movement();
    }

    
    private void FixedUpdate()
    {
        
    }
    #endregion

    private void Inputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(x, y);
    }


    /// <summary>
    /// use to flip the sprite in right left direction
    /// </summary>
    private void SpriteFlipper()
    {
        if(moveDir.x >0)
        {
            transform.localScale = Vector3.one;
        }else if (moveDir.x<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Movement()
    {
        moveDir.Normalize();//to counter diagonal movement

        ///we check weather we can move movedir.y*time.delta timnes distance at that particualr frame when we are pressing the ip
        ///1st argumnent-position to cast from,2nd arg - size of the collider,3rd arg - Angle
        ///4th arg Max distance to cast ,5th layermask which we want to know if the player collided with
        
        //this is for y direction
        hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, moveDir.y), 
            Mathf.Abs(moveDir.y * Time.deltaTime), LayerMask.GetMask("Actors", "Blocking"));
        if(hit.collider == null)
        {
            transform.Translate(0f, moveDir.y * Time.deltaTime*speed, 0f);
        }
        //this is for x direction
        hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2( moveDir.x,0f),
            Mathf.Abs(moveDir.x * Time.deltaTime), LayerMask.GetMask("Actors", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate( moveDir.x * Time.deltaTime * speed, 0f,0f);
        }

        //now this will initially will not move the player as it is colliding with itself as we are casting the box from player position and 
        //player is also on the same layer
        //so to avoid that go to physics and uncheck query start in collider,i.e it will ignore itself


    }

}
