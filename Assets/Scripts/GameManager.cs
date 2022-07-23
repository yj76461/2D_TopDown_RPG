using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public Image portraitImg;
    public bool isAction = false;
    public int talkIdx;
    public int portraitIdx;
    
    void Start() {
        Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData obj = scanObject.GetComponent<ObjData>();
        Talk(obj.id, obj.isNpc);
        talkPanel.SetActive(isAction);
        
    }

    void Talk(int id, bool isNpc)
    {
        //set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(questTalkIndex + id, talkIdx);

        //end Talk
        if(talkData == null){
            isAction = false;
            talkIdx = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }
        if(isNpc){
            talkText.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1,1,1,1);
        }
        else{
            talkText.text = talkData;
            portraitImg.color = new Color(1,1,1,0);
        }
        isAction = true;
        talkIdx++;
    }
}
