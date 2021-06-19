using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : mover
{

    private SpriteRenderer spriteRendere;
    private bool isAlive = true;
    protected override void Start()
    {
        base.Start();
        spriteRendere = GetComponent<SpriteRenderer>();
        //DontDestroyOnLoad(gameObject);
    }
    protected override void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(isAlive)
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

        GameManager.instance.OnHitPointChange();
        GameManager.instance.ShowText("+" + Healing_amoint.ToString() + "hp", 20, Color.green, transform.position, Vector3.up * 40, 1.0f);
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isAlive) return;

        base.ReceiveDamage(dmg);
        GameManager.instance.OnHitPointChange();
    }

    protected override void Death()
    {
        isAlive = false;
        GameManager.instance.deathMenuAnimator.SetTrigger("show");
        PlayerPrefs.DeleteAll();

    }
    public void PlayerRespawn()
    {
        Heal(maxHitpoint);
        isAlive = true;
        lastImmuneTime = Time.time;
    }


}
