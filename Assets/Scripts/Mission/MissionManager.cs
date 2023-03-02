using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Triggers;
using UniRx;
using UnityEngine.SceneManagement;
using System;

public class MissionManager : MonoBehaviour
{
    enum AnserRank
    {
        Great, 　　　　//大正解
        Middle, 　　　 //中正解
        SmallCorrect  //小正解
    }

    [SerializeField]
    private List<GameObject> cloneObjects;

    [SerializeField]
    private List<Vector3> cloneObjectTransform;

    [SerializeField]
    GameObject parent;

    [SerializeField]
    GameObject optionArea;

    [SerializeField]
    GameObject anser;

    [SerializeField]
    MissionJudgeController missionJudgeController;

    private QuestionsInfomation questionsInfomation;


    [SerializeField]
    List<string> talkingTextList;

    [SerializeField]
    float delayTime = 3.0f;

    [SerializeField]
    Text charactorText;

    Dictionary<int, string> dic = new Dictionary<int, string>();

    int _textCount = 0;
    bool _isShowOptionArea = false;


    int before_index = 0;
    int now_index;

    public static bool beingMeasured; // 計測中であることを表す変数

    void Start()
    {
        optionArea.SetActive(_isShowOptionArea);
        anser.SetActive(_isShowOptionArea);
        ShowStoryText();

        questionsInfomation = new QuestionsInfomation();
        questionsInfomation.Init();

        List<string[]> csvDataList = questionsInfomation.QuizList;
        int quizListCount = csvDataList.Count;

        bool loop = true;
        while (loop)
        {
            now_index = UnityEngine.Random.Range(1, quizListCount);
            if (before_index == now_index) continue;
            before_index = now_index;
            loop = false;
        }

        SetOptionsAndAnser(questionsInfomation, now_index);
    }

    private void Update()
    {
        // 右ボタンが押された瞬間に実行
        if (Input.GetKeyDown(KeyCode.N))
        {
            ShowStoryText();
        }
    }

    /// <summary>
    /// 選択肢3つと正解の値をセット
    /// </summary>
    /// <param name="num"></param>
    public void SetOptionsAndAnser(QuestionsInfomation questions , int num)
    {
        QuestionData.Instance.SetOption1(questions.Options1[num]);
        QuestionData.Instance.SetOption2(questions.Options2[num]);
        QuestionData.Instance.SetOption3(questions.Options3[num]);
        QuestionData.Instance.SetAnser(questions.Answer[num]);
    }

    /// <summary>
    /// ストーリーのテキスト表示管理
    /// </summary>
    public void ShowStoryText()
    {
        if (_textCount == talkingTextList.Count -2)
        {
            ShowOptionArea();
            //MoveOptionArea();
        }

        if (_textCount != talkingTextList.Count)
        {
            charactorText.text = talkingTextList[_textCount];
            _textCount += 1;
        }
    }

    /// <summary>
    /// 選択肢3つのパネル表示・非表示切り替え
    /// </summary>
    public void ShowOptionArea()
    {
        _isShowOptionArea = !_isShowOptionArea;
        optionArea.SetActive(_isShowOptionArea);
        anser.SetActive(_isShowOptionArea);

        Transform children = optionArea.GetComponentInChildren<Transform>();
        foreach (Transform ob in children)
        {
            // "Option"タグがついていないオブジェクトの場合はcontinueする
            if (!ob.gameObject.CompareTag("Option")) continue;

            // 各選択肢のオブジェクトの"IsSelected"がtrueではない場合はcontinueする
            OptionController optionController = ob.GetComponent<OptionController>();
            optionController.GetItemData();
        }
    }

    /// <summary>
    /// 選択肢選んだ後の処理
    /// </summary>
    public void SelectedAnser()
    {
        Transform children = optionArea.GetComponentInChildren<Transform>();
        optionArea.SetActive(false);

        foreach (Transform ob in children)
        {
            // "Option"タグがついていないオブジェクトの場合はcontinueする
            if (!ob.gameObject.CompareTag("Option")) continue;

            // 各選択肢のオブジェクトの"IsSelected"がtrueではない場合はcontinueする
            OptionController optionController = ob.GetComponent<OptionController>();
            if (!optionController.IsSelected) continue;

            // 選んだ選択肢の中央に表示、テキストも差し替え
            anser.GetComponentInChildren<Text>().text = optionController.optionName.text;

            ShowStoryText();
            SetTownPoint(ob.GetComponent<OptionController>().Score);
            StartCoroutine(BackAreaDelay());
        }
    }

    /// <summary>
    /// 回答に合わせたスコアを保存
    /// </summary>
    /// <param name="Score"></param>
    void SetTownPoint(int Score)
    {
        UserData.Instance.SetTownScore(Score);
    }

    /// <summary>
    /// 街エリアへ戻る
    /// </summary>
    public void BackTownArea()
    {
        SceneManager.LoadScene("Town");
    }

    /// <summary>
    /// ミッション終了後エリアに戻るまでの待機時間
    /// </summary>
    /// <returns></returns>
    IEnumerator BackAreaDelay()
    {
        yield return new WaitForSeconds(delayTime);
        BackTownArea();

    }
}
