using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction = false;
    
    public void Action(GameObject scanObj)
    {
        if(isAction){
            isAction = false;
        }
        else{
            isAction = true;
            scanObject = scanObj;
            talkText.text = "아아, 이것의 이름은, " + scanObj.name + " 이다.";
        }
        talkPanel.SetActive(isAction);
        
    }
}
