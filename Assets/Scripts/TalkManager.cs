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
        //talk data
        talkData.Add(1000, new string[] {"반가워요!:0" , "세리아 키르민이라고 해요~:2"});
        talkData.Add(2000, new string[] {"...:1", "....:1", ".....:1", "......:1", "깜짝이야:3", "난 여기서 새로운 지형을 탐험하고 있었어:0", "모험을 한다는 것은 굉장히 멋진 일이야!:0", "너도 그렇게 생각하지?:2"});
        talkData.Add(3000, new string[] {"안에 무언가 움직이는 것 같다."});
        talkData.Add(4000, new string[] {"책상 위엔 알 수 없는 자료들이 놓여져 있다."});

        //quest talk data
        talkData.Add(10 + 1000, new string[] {"누구시죠?:0" , 
                                            "모험을 떠나 이곳에 도착하셨다구요?:2", 
                                            "며칠 전에도 또 다른 모험가가 저희 마을에 오긴 했었죠..: 2",
                                            "아마 그녀는 마을 오른쪽 호수 근처에 있을 겁니다.:0",
                                            "한번 대화를 나누어 보시는 편이 좋겠네요:0"});

        talkData.Add(11 + 2000, new string[] {"반가워.:1" , 
                                            "혹시 너도 모험을 하다가 이 마을에 온거니?:1", 
                                            "그렇구나~ 나도 모험가야!: 2",
                                            "그런데 혹시 오는 길에 나침반 못 봤니?:0",
                                            "마을에 도착해서 나침반을 보려고 했는데 없어진 것 같아:3",
                                            "괜찮다면 혹시 찾아주지 않을래? 보상은 확실하게 해줄게!!:2"});

        talkData.Add(20 + 1000, new string[] {"나침반?:1" , 
                                            "그런 걸 본 것 같기도 하고...:1", 
                                            "아! 풀숲 어딘가에서 본 것 같네요!: 2",
                                            "꼭 찾으시길 바랍니다.:0",
                                            "세상이 워낙 흉흉하니까요.. 몸 조심하세요:3"});
        
        talkData.Add(20 + 2000, new string[] {"뭐야:1" , 
                                            "아직 못 찾은거야?:3", 
                                            "조금만 더 찾아보자!: 2",
                                            "모험가라면 금방 찾을 수 있을거야:0"});

        talkData.Add(20 + 5000, new string[] {"근처에서 나침반을 발견했다. 아무래도 그 여자 것이 맞는 것 같다."});

        talkData.Add(21 + 2000, new string[] {"정말 찾아줬구나 고마워!!:2"});
        //portrait Data
        portraitData.Add(2000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 1, portraitArr[1]);
        portraitData.Add(2000 + 2, portraitArr[2]);
        portraitData.Add(2000 + 3, portraitArr[3]);

        portraitData.Add(1000 + 0, portraitArr[4]);
        portraitData.Add(1000 + 1, portraitArr[5]);
        portraitData.Add(1000 + 2, portraitArr[6]);
        portraitData.Add(1000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIdx)
    {
        // 예외처리 파트
        if(!talkData.ContainsKey(id))
        {
            if(!talkData.ContainsKey(id - id % 10))
            {
                // 퀘스트 맨 처음 대사 조차 없다면 기본 대사를 가져온다.
                return GetTalk(id - id % 100, talkIdx);
            }
            else{
                // 퀘스트 진행 순서 중 대사가 없을 때 다시 첫 멘트로 돌아감
                return GetTalk(id - id % 10, talkIdx);
            }

        }
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
