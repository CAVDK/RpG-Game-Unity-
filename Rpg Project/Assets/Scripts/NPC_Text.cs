using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Text : Collidable
{
    public string message;
    public float coolDown = 4f;
    private float lastTalk;
    protected override void Start()
    {
        base.Start();
        lastTalk = -coolDown;
    }
    protected override void OnCollide(Collider2D coll)
    {
        if(Time.time - lastTalk >coolDown)
        {
            lastTalk = Time.time;
            GameManager.instance.ShowText(message, 25, Color.white, transform.position +Vector3.up*0.16f, Vector3.zero, 4.0f);
            

        }

    }
}
