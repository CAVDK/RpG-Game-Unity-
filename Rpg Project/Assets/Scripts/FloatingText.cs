using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatingText
{ 
    public bool active;
    public GameObject go;
    public Text _text;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    //afuncion for hiding details
    public void Hide()
    {
        active = false;
        lastShown = Time.time;
        go.SetActive(false);
    }
    
    //function for showing details
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(true);
    }

    public void UpdateFloatingText()
    {
        if (!active) return;

        //hide the text if we are showing it for too long
        if(Time.time -lastShown>duration)
        {
            Hide();
        }
        go.transform.position += motion * Time.deltaTime;
                
    }

}
