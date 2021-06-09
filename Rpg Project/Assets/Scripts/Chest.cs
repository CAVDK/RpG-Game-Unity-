
using UnityEngine;

public class Chest : Collactable
{

    public Sprite emptyChest;
    public int moneyAmount = 10;
    protected override void Collect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;

            //vector3.up *50 px this mean that we are going 50 px up in a sec
            GameManager.instance.ShowText("+" + moneyAmount + "Moneyyy!", 30, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
            Debug.Log($" granted {moneyAmount} to player");
        }
    }

}
