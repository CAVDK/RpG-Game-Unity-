using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : mover
{
    //experiancee;
    public int xpValue = 1;

    //locgic
    public float triggerLenght = 1;
    public float chaseLenght = 5;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;
  

    //enemy weapon HitBox
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    private ContactFilter2D _filter;

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        //maxdistance the enemy can have between him and the player once the player goes x amount of distance away from the player it stops
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght)
        {
            //if player is in the range of the trigger move the enemy
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)
            {
                chasing = true;
            }
            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
                chasing = false;
                
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        //check for any overlap
        collidingWithPlayer = false;
            _boxCollider.OverlapCollider(_filter, hits);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i] == null)
                {
                    continue;
                }

                if(hits[i].tag =="Fighter" && hits[i].name == "Player" )
                {
                    collidingWithPlayer = true;
                }



                hits[i] = null;//clear out the array after using 
            }


    }
    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.Grantxp(xpValue);
        GameManager.instance.ShowText("+ wowo", 30, Color.white, transform.position, Vector3.up * 50, 1.0f);
    }

}

    
   


