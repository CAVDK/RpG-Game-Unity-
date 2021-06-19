using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {

        if (instance != null)
        {
            
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(HUD.gameObject);
            Destroy(menu.gameObject);


            return;

        }
        //else
        //{
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += LoadData;
        SceneManager.sceneLoaded += OnSceanLoaded;
        //}
        
       // SceneManager.sceneLoaded += LoadData;
        
    }

    //resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;


    //refrence to various game objects like player npsc etc
    public PlayerMovement player;
    public Weapon _weapon;
    public GameObject HUD;
    public GameObject menu;
    public Animator deathMenuAnimator;



    //weapon script reftrence to text ;
    public FloatingTextManager floatingTextManager;
    public RectTransform hitPointBar;


    //tracking variables
    public int money;
    public int experience;



    private void Update()
    {
       Debug.Log( GetCurrentLevel());   
    }

    ///Common place to show message
    public void ShowText(string msg,int fontSize,Color color ,Vector3 position, Vector3 motion,float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public bool TryUpgradeWeapon()
    {
        //is weapon level max
        if (weaponPrices.Count <= _weapon.weaponLevel) return false;

        if(money>=weaponPrices[_weapon.weaponLevel])
        {
            money -= weaponPrices[_weapon.weaponLevel];
            _weapon.UpGradeWeapon();
            return true;
        }
        return false;

    }


    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;
        while(experience>=add)
        {
            add += xpTable[r];
            
            r++;
            if (r == xpTable.Count)
                return r;
        }
        
        return r;
    }

    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;
        while(r<level)
        {
            xp += xpTable[r];
            r++;
        }
        return xp;
    }

    public void Grantxp(int xp)
    {
        int currLevel = GetCurrentLevel();
        experience += xp;
        if(currLevel <GetCurrentLevel())
        {
            OnLevelUp();
        }
    }

    public void OnLevelUp()
    {
        Debug.Log("Level Up");
        player.OnLevelUp();
        OnHitPointChange();
    }


    //function to save the game data
    public void SaveState()
    {

        string save_data = "";

        save_data += "0" + "|";
        save_data += money.ToString() + "|";
        save_data += experience.ToString() + "|";
        save_data += _weapon.weaponLevel.ToString();

        PlayerPrefs.SetString("saveData", save_data);
    }
    
    //function to Load the data from the game when you open
    public void LoadData( Scene s ,LoadSceneMode mode)
    {
       // Debug.Log("load data");
       
        SceneManager.sceneLoaded -= LoadData;
        //we only load the data once and then carry it throughout the sceans as we are using donot destroy on load
        if (!PlayerPrefs.HasKey("saveData"))//if we dont have a key in the game
        {
            return;
        }


        string[] data = PlayerPrefs.GetString("saveData").Split('|');
        money = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        if(GetCurrentLevel() !=1)
        player.SetLevel(GetCurrentLevel());
       
        _weapon.SetWeaponLevel(int.Parse(data[3]));
        

    }

    public void OnSceanLoaded(Scene s, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }

    //hitpoint bar
    public void OnHitPointChange()
    {
        float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
        hitPointBar.localScale = new Vector3(1, ratio, 1);
    }


    //repawn Death Menu
    public void Respawn()
    {
        deathMenuAnimator.SetTrigger("hide");
        PlayerPrefs.DeleteAll();
        
        player.PlayerRespawn();
        money = 10;
        experience = 0;
        _weapon.SetWeaponLevel(0);
        player.SetLevel(0);

        SceneManager.LoadScene("start");
        

    }





}
