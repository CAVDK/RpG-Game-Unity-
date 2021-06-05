using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Variables Declarations
    //requirements
    private BoxCollider2D _boxCollider;

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
        transform.Translate(moveDir * Time.deltaTime*speed);
    }

}
