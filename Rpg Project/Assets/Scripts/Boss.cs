using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public float[] fireBallSpeed ;
    public float distance;
    public Transform[] firBall;
    protected override void Update()
    {
        base.Update();

        for (int i = 0; i <firBall.Length; i++)
        {
            firBall[i].position = transform.position +
            new Vector3(-Mathf.Cos(Time.time * fireBallSpeed[i]) * distance, Mathf.Sin(Time.time * fireBallSpeed[i]) * distance, 0f);
        }
        

    }


}
