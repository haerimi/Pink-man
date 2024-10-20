using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    public int count = 0;
    public GameManager game;



   
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();


        GenerateData();
    }
    void GenerateData()
    {

        // 스테이지 1

        talkData.Add(100, new string[] { "어라? 이런곳에 왜 딸기가 떨어져 있지?:0", "일단 맛있어 보이니 가져가야 겠다.:0",
                "거기 누구 있어?:2","이게 무슨소리지?:0", "일단 소리나는 쪽으로 가볼까?:0"});

        talkData.Add(1000, new string[] { "너 떨어져 있는 딸기들 봤지?:2", "응. 몇개 주웠어:0",
            "그거 내가 대장님한테 가져가다가 떨어트렸는데:2", "딸기 말고도 다른 과일들을 떨어트려서 말이야..:2",
        "혹시 괜찮으면 줍는것 좀 도와줄래?:2", "나 혼자 줍기엔 양이 많아서 말이야.:2",
            "주워주면 나한텐 뭐가 좋은데?:0",
        "음..:2", "너도 좀 나눠줄게:2", "그럼 6대 4로 나누자.:0","참고로 내가 6이야.:0",
            "어쩔 수 없지. 부탁할게:2", "(양아치 같은 놈..):2"});

        // 스테이지 2
        talkData.Add(2000, new string[] { "여기부터는 밑에 가시가 있어서 조심해야 할거야.:2", "근데 과일 종류는 뭐뭐 있어?:0",
            "딸기 말고도 바나나, 키위가 있어.:2", "오호라. 알겠어!:0", "(뭔가 좀 불안한데..):2", "아무튼 몸 조심해!:2"

        });

        talkData.Add(3000, new string[] { "어이-! 거기 너!:3", "뭐야, 나 지나가야 하는데:0", "별건 아니고:3", "주운 과일들 좀 줘봐:3",
        "싫어. 내가 주운거란 말이야.:0", "말로 해서는 안되겠군.:3", "아악 뭐야-!!:0", "말이 통하지 않는다면, 무력으로 뺏는 수 밖에!:3",
        "거기서!:0"});

        // 스테이지 3
        talkData.Add(4000, new string[] { "과일은 좀 모았어?:2",  "아니.. 어떤 놈한테 뺏겼어!!:0", "엥 누구한테??:2",
        "몰라. 무슨 이상한 가면 쓰고 있던데.:0", "(이상한 가면?):2", "그거 혹시..:2", "내가 무슨일이 있어도 다시 가져올테다!:0",
        "아니 잠깐:2", "간다!!:0", "말도 다 안듣고 가네..:2", "나중에 보면 알겠지 뭐.:2"});

        talkData.Add(5000, new string[] { "뭐야! 너네 왜 같이있어?!:0", "아까 말하려고 했는데 너가 그냥 갔잖아:2", 
            "처음 만났을 때 내가 뭐라고 했는지 기억해?:2", "과일 주워 달라는거?:0", "아니, 그거말고.:2",
            "대장님한테 준다고 그랬잖아.:2", "그 대장님이 이 분이셔:2", "대장이 뭐 저리 괴팍해!:0",
        "크하하하-!:3", "심심해서 가만 있을 수 있어야지!:3", "놀랐다면 미안하다!:3", "됐고, 과일은 언제 줄거야?:0",
        "알았어, 줄테니가 재촉하지마:2", "이것도 인연인데, 우리 마을에서 열리는 축제에 초대하도록 하지!:3", "예?:2", "축제면.. 먹을거 좀 있나?:0",
        "아주 많지!:3", "그럼 갈래!:0","아니..:2", "당차서 좋군! 얼른 가지.:3", "어휴.. 네 갑니다요.:2", "(또 일이 커지겠군.):2"});
        portraitData.Add(100 + 0, portraitArr[0]); // 플레이어 기본 모습
        portraitData.Add(100 + 2, portraitArr[2]); // 개구리 기본 모습


        portraitData.Add(1000 + 0, portraitArr[0]); // 플레이어 기본 모습
        portraitData.Add(1000 + 2, portraitArr[2]); // 개구리 기본 모습

        portraitData.Add(2000 + 0, portraitArr[0]); // 플레이어 기본 모습
        portraitData.Add(2000 + 2, portraitArr[2]); // 개구리 기본 모습

        portraitData.Add(3000 + 0, portraitArr[0]); // 플레이어 기본 모습
        portraitData.Add(3000 + 3, portraitArr[3]); // 빌런 기본 모습

        portraitData.Add(4000 + 0, portraitArr[0]); // 플레이어 기본 모습
        portraitData.Add(4000 + 2, portraitArr[2]); // 개구리 기본 모습
        portraitData.Add(4000 + 3, portraitArr[3]); // 빌런 기본 모습

        portraitData.Add(5000 + 0, portraitArr[0]); // 플레이어 기본 모습
        portraitData.Add(5000 + 2, portraitArr[2]); // 개구리 기본 모습
        portraitData.Add(5000 + 3, portraitArr[3]); // 빌런 기본 모습




    }

    public string GetTalk(int id, int talkIndex) {

        if (talkIndex == talkData[id].Length && id == 100)
        {
            GameObject.Find("Item").transform.Find("Start_Strawberry").gameObject.SetActive(false);
            GameObject.Find("Item").transform.Find("uin").gameObject.SetActive(false);

            return null;
        }

        else if (talkIndex == talkData[id].Length && id == 1000)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                game.NextStage();

            }
            return null;
        }

        else if (talkIndex == talkData[id].Length && id == 3000)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                game.NextStage();

            }
            return null;
        }

        else if (talkIndex == talkData[id].Length && id == 5000)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                game.NextStage();

            }
            return null;
        }


        else if (talkIndex == talkData[id].Length)
        {
            return null;
        }

        else
            return talkData[id][talkIndex];

    }

    public Sprite GetPortrait (int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
