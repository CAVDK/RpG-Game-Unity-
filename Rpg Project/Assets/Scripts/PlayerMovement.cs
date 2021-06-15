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
}
