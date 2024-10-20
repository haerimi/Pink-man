using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMove player;
    public GameObject[] Stages;
    public Animator talkPanel;
    public TypeEffect talk;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public TalkManager talkManager;
    public Image portraitImg;
    public Animator portraitAnim;
    public Sprite prevPortrait;
    public bool isGameover = false;
    public int btnCount;
    // ���� ����
    public int stagePoint;
    public int stageIntext;
    public int totalPoint;

    // UI �迭
    public Image[] UIhealth;

    // ü��
    public int health;
    // UI
    public Text UIPoint;
    public Text UIStage;

    public GameObject RestartBtn;     //�׾��� �� ���̴� ��ư


    public void NextStage()
    {

        //Chage Stage
        if (stageIntext < Stages.Length - 1)
        {
            Stages[stageIntext].SetActive(false);
            stageIntext++;
            Stages[stageIntext].SetActive(true);
            PlayerReposition();
            if (stageIntext == 0)
                UIStage.text = "������ ��";

            else if (stageIntext == 1)
                UIStage.text = "���� ����";
            else if (stageIntext == 2)
                UIStage.text = "������ ���� ��";
        }
        else
        {
            // Game Clear
            //Player Contro; Lock
            Time.timeScale = 0;
            Debug.Log("���� Ŭ����");
            // Restart Button UI
            //Text btnText = RestartBtn.GetComponentInChildren<Text>();
            //btnText.text = "Game Clear";
            RestartBtn.SetActive(true);
            SceneManager.LoadScene("Clear");

        }
        // Calculate Point
        totalPoint += stagePoint;
        stagePoint = 0;
    }


    void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
        if (isGameover && Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        Item item = scanObject.GetComponent<Item>();
        Talk(item.id, item.isNpc);
        Debug.Log(Stages.Length);
        Debug.Log(stageIntext);
        
        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc) {
        // Set Talk Data
        string talkData = "";

        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            talkData = talkManager.GetTalk(id, talkIndex);
        }

        if (talkData == null) {
            isAction = false;
            talkIndex = 0;
            return;         // ��������
        }

        if (isNpc){
            talk.SetMsg(talkData.Split(':')[0]);

            // Show Portrait
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);

            // Animation Portrait
            if (prevPortrait != portraitImg.sprite) { 
                portraitAnim.SetTrigger("doEffet");
                prevPortrait = portraitImg.sprite;
            }

        }

        else {
            talk.SetMsg(talkData.Split(':')[0]);

            // Show Portrait
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);

            // Animation Portrait
            if (prevPortrait != portraitImg.sprite)
            {
                portraitAnim.SetTrigger("doEffet");
                prevPortrait = portraitImg.sprite;
            }

        }

        isAction = true;
        talkIndex++;
    }


    public void OnPlayerDead() {
        isGameover = true;
        RestartBtn.SetActive(true);
    }


    public void HealthDown() {
        if (health > 0)
        {
            health--;
            UIhealth[health].color = new Color(1, 1, 1, 0.2f);
        }
        else if (health == 0)
        {
            UIhealth[0].color = new Color(1, 1, 1, 0.2f);

            // Result UT
            Debug.Log("�׾���� ���!");
            RestartBtn.SetActive(true);
        }
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void PlayerReposition() {
        player.transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
    }
}