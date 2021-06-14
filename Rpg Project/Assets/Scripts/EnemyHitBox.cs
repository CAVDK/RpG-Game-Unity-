using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : Collidable
{
    //damage
    public int damage=1;
    public float pushForce=10f;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter" && coll.name =="Player")
        {

            Damage dmg = new Damage
            {
                damageAmount = damage,
                attackOrigin = transform.position,
                pushForce = pushForce

            };
            coll.SendMessage("ReceiveDamage", dmg);


        }
    }
}
