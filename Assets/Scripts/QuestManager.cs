using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("새로운 모험", new int[] {1000, 2000}));
        questList.Add(20, new QuestData("모험가의 잃어버린 나침반", new int[] {5000, 2000}));
        questList.Add(30, new QuestData("퀘스트 올 클리어!!!!", new int[] {0}));

    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        

        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        ControlObject();
        
        if(questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }


    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch(questId)
        {
            case 10:
                if(questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if(questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}
