using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactable : Collidable
{
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        collected = true;
    }
}
