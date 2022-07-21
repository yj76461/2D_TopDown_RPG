using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary <int, string[]> talkData;
    Dictionary <int, Sprite> portraitData;

    public Sprite[] portraitArr;
    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    
    void GenerateData()
    {
        talkData.Add(1000, new string[] {"...:1", "....:1", ".....:1", "......:1", "깜짝이야:3", "난 여기서 새로운 지형을 탐험하고 있었어:0", "모험을 한다는 것은 굉장히 멋진 일이야!:0", "너도 그렇게 생각하지?:2"});
        talkData.Add(2000, new string[] {"반가워요!:0" , "세리아 키르민이라고 해요~:2"});
        talkData.Add(100, new string[] {"안에 무언가 움직이는 것 같다."});
        talkData.Add(200, new string[] {"책상 위엔 알 수 없는 자료들이 놓여져 있다."});

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);

        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIdx)
    {
        if(talkIdx == talkData[id].Length)
            return null;
        else{
            return talkData[id][talkIdx];
        }
    }

    public Sprite GetPortrait(int id, int portraitIdx)
    {
        return portraitData[id + portraitIdx];
    }

}
