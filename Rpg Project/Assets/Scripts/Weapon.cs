using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon :Collidable
{
    //weapon damage
    public int[] damagePoint = {1,2,3,4,5,6,7 };
    public float[] pushBackForce = {3f,3.3f,3.6f,3.9f,4f,4.3f,4.5f };

    //upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRendere;

    //weapomn attack - swing
    private float weapon_coolDown =0.5f;
    private float lastSwing;
    private Animator animator;



    private void Awake()
    {
        spriteRendere = GetComponent<SpriteRenderer>();

    }
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("swing");

    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
            {
                return;
            }
            Debug.Log("i hit the enemy" + coll.name);
            //we create a new damage obj and then send it to the enemy we hit

            Damage dmg = new Damage
            {
                damageAmount = damagePoint[weaponLevel],

                attackOrigin = transform.position,

                pushForce = pushBackForce[weaponLevel]
            };
            coll.SendMessage("ReceiveDamage", dmg);

        }
    }
    

    public void UpGradeWeapon()
    {
        weaponLevel++;
        
        spriteRendere.sprite = GameManager.instance.weaponSprites[weaponLevel];
        //cahnge stats
    }

    public void SetWeaponLevel( int level)
    {
        weaponLevel = level;
        spriteRendere.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}

