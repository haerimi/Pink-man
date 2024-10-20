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

        // �������� 1

        talkData.Add(100, new string[] { "���? �̷����� �� ���Ⱑ ������ ����?:0", "�ϴ� ���־� ���̴� �������� �ڴ�.:0",
                "�ű� ���� �־�?:2","�̰� �����Ҹ���?:0", "�ϴ� �Ҹ����� ������ ������?:0"});

        talkData.Add(1000, new string[] { "�� ������ �ִ� ����� ����?:2", "��. � �ֿ���:0",
            "�װ� ���� ��������� �������ٰ� ����Ʈ�ȴµ�:2", "���� ���� �ٸ� ���ϵ��� ����Ʈ���� ���̾�..:2",
        "Ȥ�� �������� �ݴ°� �� �����ٷ�?:2", "�� ȥ�� �ݱ⿣ ���� ���Ƽ� ���̾�.:2",
            "�ֿ��ָ� ������ ���� ������?:0",
        "��..:2", "�ʵ� �� �����ٰ�:2", "�׷� 6�� 4�� ������.:0","����� ���� 6�̾�.:0",
            "��¿ �� ����. ��Ź�Ұ�:2", "(���ġ ���� ��..):2"});

        // �������� 2
        talkData.Add(2000, new string[] { "������ʹ� �ؿ� ���ð� �־ �����ؾ� �Ұž�.:2", "�ٵ� ���� ������ ���� �־�?:0",
            "���� ���� �ٳ���, Ű���� �־�.:2", "��ȣ��. �˰ھ�!:0", "(���� �� �Ҿ��ѵ�..):2", "�ƹ�ư �� ������!:2"

        });

        talkData.Add(3000, new string[] { "����-! �ű� ��!:3", "����, �� �������� �ϴµ�:0", "���� �ƴϰ�:3", "�ֿ� ���ϵ� �� ���:3",
        "�Ⱦ�. ���� �ֿ�Ŷ� ���̾�.:0", "���� �ؼ��� �ȵǰڱ�.:3", "�ƾ� ����-!!:0", "���� ������ �ʴ´ٸ�, �������� ���� �� �ۿ�!:3",
        "�ű⼭!:0"});

        // �������� 3
        talkData.Add(4000, new string[] { "������ �� ��Ҿ�?:2",  "�ƴ�.. � ������ �����!!:0", "�� ��������??:2",
        "����. ���� �̻��� ���� ���� �ִ���.:0", "(�̻��� ����?):2", "�װ� Ȥ��..:2", "���� �������� �־ �ٽ� �������״�!:0",
        "�ƴ� ���:2", "����!!:0", "���� �� �ȵ�� ����..:2", "���߿� ���� �˰��� ��.:2"});

        talkData.Add(5000, new string[] { "����! �ʳ� �� �����־�?!:0", "�Ʊ� ���Ϸ��� �ߴµ� �ʰ� �׳� ���ݾ�:2", 
            "ó�� ������ �� ���� ����� �ߴ��� �����?:2", "���� �ֿ� �޶�°�?:0", "�ƴ�, �װŸ���.:2",
            "��������� �شٰ� �׷��ݾ�.:2", "�� ������� �� ���̼�:2", "������ �� ���� ������!:0",
        "ũ������-!:3", "�ɽ��ؼ� ���� ���� �� �־����!:3", "����ٸ� �̾��ϴ�!:3", "�ư�, ������ ���� �ٰž�?:0",
        "�˾Ҿ�, ���״ϰ� ����������:2", "�̰͵� �ο��ε�, �츮 �������� ������ ������ �ʴ��ϵ��� ����!:3", "��?:2", "������.. ������ �� �ֳ�?:0",
        "���� ����!:3", "�׷� ����!:0","�ƴ�..:2", "������ ����! �� ����.:3", "����.. �� ���ϴٿ�.:2", "(�� ���� Ŀ���ڱ�.):2"});
        portraitData.Add(100 + 0, portraitArr[0]); // �÷��̾� �⺻ ���
        portraitData.Add(100 + 2, portraitArr[2]); // ������ �⺻ ���


        portraitData.Add(1000 + 0, portraitArr[0]); // �÷��̾� �⺻ ���
        portraitData.Add(1000 + 2, portraitArr[2]); // ������ �⺻ ���

        portraitData.Add(2000 + 0, portraitArr[0]); // �÷��̾� �⺻ ���
        portraitData.Add(2000 + 2, portraitArr[2]); // ������ �⺻ ���

        portraitData.Add(3000 + 0, portraitArr[0]); // �÷��̾� �⺻ ���
        portraitData.Add(3000 + 3, portraitArr[3]); // ���� �⺻ ���

        portraitData.Add(4000 + 0, portraitArr[0]); // �÷��̾� �⺻ ���
        portraitData.Add(4000 + 2, portraitArr[2]); // ������ �⺻ ���
        portraitData.Add(4000 + 3, portraitArr[3]); // ���� �⺻ ���

        portraitData.Add(5000 + 0, portraitArr[0]); // �÷��̾� �⺻ ���
        portraitData.Add(5000 + 2, portraitArr[2]); // ������ �⺻ ���
        portraitData.Add(5000 + 3, portraitArr[3]); // ���� �⺻ ���




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
