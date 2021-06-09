using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;//collider and filter go hand in hand we can do various thing with it
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];//used 10 as a random value; //use to store what the player collided wiith


    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    protected virtual void Update()
    {
        //used to detect collision and do all the collision work
        boxCollider.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i]==null)
            {
                continue;
            }

            OnCollide(hits[i]);



            hits[i] = null;//clear out the array after using 
        }
    }

    protected  virtual void OnCollide(Collider2D coll)
    {
        Debug.Log( " On collided was not over written here i.e in  "+ this.name);
    }
}
