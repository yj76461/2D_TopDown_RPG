using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator talkPanel;
    public Animator portraitAnim;
    public Sprite prevSprite;
    public TypeEffect talk;
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
        talkPanel.SetBool("isShow", isAction);
        
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";
        //set Talk Data
        if(talk.isAnim){
            talk.SetMsg("");
            return;
        }
        else{
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(questTalkIndex + id, talkIdx);
        }

        //end Talk
        if(talkData == null){
            isAction = false;
            talkIdx = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }
        if(isNpc){
            talk.SetMsg(talkData.Split(':')[0]);
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1,1,1,1);
            if(prevSprite != portraitImg.sprite){
                portraitAnim.SetTrigger("doEffect");
                prevSprite = portraitImg.sprite;
            }

        }
        else{
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1,1,1,0);
        }
        isAction = true;
        talkIdx++;
    }
}
