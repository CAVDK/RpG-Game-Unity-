
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
            Debug.Log($" granted {moneyAmount} to player");
        }
    }

}
