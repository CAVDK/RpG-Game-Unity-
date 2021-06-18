using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : mover
{

    private SpriteRenderer spriteRendere;
    protected override void Start()
    {
        base.Start();
        spriteRendere = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }


    public void SwapSprite(int skinId)
    {
        spriteRendere.sprite = GameManager.instance.playerSprites[skinId];
    }

    public void OnLevelUp()
    {
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }

    public void Heal(int Healing_amoint)
    {
        if (hitpoint == maxHitpoint) return;

        hitpoint += Healing_amoint;
        if (hitpoint>maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }
       
       
            GameManager.instance.ShowText("+" + Healing_amoint.ToString() + "hp", 20, Color.green, transform.position, Vector3.up * 40, 1.0f);
    }


}
