using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textConatnier;//the game object to which this scipt is attached to
    public GameObject textPrefab; //a simple text prefab

    public List<FloatingText> floatingTexts = new List<FloatingText>();


    private void Update()
    {
        foreach(FloatingText txt in floatingTexts)
        {
            txt.UpdateFloatingText();
        }
            
    }

    public void Show(string msg,int fontSize,Color color,Vector3 position,Vector3 motion,float duration)
    {
        FloatingText floatingText = GetFloatingText();
        if(!floatingText.active)
        {
            floatingText.active = true;
        }
        floatingText._text.text = msg;
        floatingText._text.fontSize = fontSize;
        floatingText._text.color = color;
        //transfer world to screen space to use it in ui
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;
        floatingText.Show();

    }

    //pool
    private FloatingText GetFloatingText()
    {
        //inu,erable jasons tut
        FloatingText text = floatingTexts.Find(t => !t.active);

        if(text == null)
        {
            text = new FloatingText();
            text.go = Instantiate(textPrefab);
            text.go.transform.SetParent(textConatnier.transform);
            text._text = text.go.GetComponent<Text>();
            floatingTexts.Add(text);


        }

        return text;
    }
}
