using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{

    public string  sceneName;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            //pick a random dngon to spawn 
            GameManager.instance.SaveState();
            
            SceneManager.LoadScene(sceneName);

        }
    }
}
