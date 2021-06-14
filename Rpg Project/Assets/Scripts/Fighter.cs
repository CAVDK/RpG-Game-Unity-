using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint =10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float immunityTime = 1.0f;
    protected float lastImmuneTime;

    protected Vector3 pushDirection;

    //all the fighters can recive damange and die

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmuneTime >immunityTime)
        {
            lastImmuneTime = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.attackOrigin).normalized * dmg.pushForce;
            Debug.Log("Hit in  middle");
            GameManager.instance.ShowText(dmg.damageAmount.ToString() +"  I Hit", 30, Color.yellow, transform.position, Vector3.up *20f , 1.0f);

            if(hitpoint<=0)
            {
                hitpoint = 0;
                Death();
            }
        }

    }

    protected virtual void Death()
    {

    }




}
