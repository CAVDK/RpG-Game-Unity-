using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // field on the menu 
    public Text levlText, hitPointText, moneyText, upgradeCostText, xpText;
    public Image charcaterSelectionSprite;
    public Image weapSprite;
    public RectTransform xpBar;

    //logic
    private int currentCharacterSelection = 0;


    //caracterSelection
    public void OnArrowclick(bool arrow)
    {
      if(arrow)
        {
            currentCharacterSelection++;

            //if the array is out of bounds
            if(currentCharacterSelection == GameManager.instance.playerSprites.Count)
            {
                currentCharacterSelection = 0;
            }
            OnSelectionChange();
        }
        else
        {
            currentCharacterSelection--;

            //if the array is out of bounds
            if (currentCharacterSelection <0)
            {
                currentCharacterSelection = GameManager.instance.playerSprites.Count-1;

            }
            OnSelectionChange();
        }
    }

    private void OnSelectionChange()
    {
        charcaterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }


    //weapon Upgrade

    public void OnClickUpgrade()
    {
        //update the charcter info
        
    }

    public void Update()
    {
        //weapon
        weapSprite.sprite = GameManager.instance.weaponSprites[0];
        upgradeCostText.text = "NOT IMPLEMENTED";   

        //meta
        hitPointText.text = GameManager.instance.player.hitpoint.ToString();
        moneyText.text = GameManager.instance.money.ToString();
        levlText.text = "NOT IMPLEMENTE";

        //XP BAR
        xpText.text = "nOT IMPLEMENTED";
        xpBar.localScale = new Vector3(0.5f, 0f, 0f);

        
    }


}
