using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon :Collidable
{
    //weapon damage
    public int damagePoint;
    public int pushBackForce;

    //upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRendere;

    //weapomn attack - swing
    private float weapon_coolDown =0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRendere = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing>weapon_coolDown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    private void Swing()
    {
        Debug.Log("Swing");
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if(coll.name ==  "Player")
            {
                return;
            }
            Debug.Log("i hit the enemy" + coll.name);
            //we create a new damage obj and then send it to the enemy we hit

            Damage dmg = new Damage
            {
                damageAmount = damagePoint,

                attackOrigin = transform.position,

                pushForce = pushBackForce
            };
            coll.SendMessage("ReceiveDamage", dmg);

        }
         
    }


}
