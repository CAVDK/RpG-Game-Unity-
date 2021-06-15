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
        GameManager.instance.player.SwapSprite(currentCharacterSelection);
    }


    //weapon Upgrade

    public void OnClickUpgrade()
    {
        //update the charcter info
        if (GameManager.instance.TryUpgradeWeapon())
        {
            UpdateMenu();
        }
        
    }

    public void UpdateMenu()
    {
        //weapon
        weapSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance._weapon.weaponLevel];

        if (GameManager.instance._weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradeCostText.text = "max";
        else
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance._weapon.weaponLevel].ToString();

        //meta
        hitPointText.text = GameManager.instance.player.hitpoint.ToString();
        moneyText.text = GameManager.instance.money.ToString();
        levlText.text = GameManager.instance.GetCurrentLevel().ToString();
        int currentLevel = GameManager.instance.GetCurrentLevel();


        //XP BAR
        if (currentLevel ==  GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + "total exp points";
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManager.instance.GetXpToLevel(currentLevel-1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currentLevel);
            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1f, 1f);
            xpText.text = currXpIntoLevel.ToString() + "/" + diff;

        }



        
    }


}
