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
        questionsInfomation.Reset();
        questionsInfomation.Init();

        List<string[]> csvDataList = questionsInfomation.QuizList;
        int quizListCount = csvDataList.Count;
        Debug.Log("quizListCount: " + quizListCount);

        bool loop = true;
        while (loop)
        {
            now_index = UnityEngine.Random.Range(1, quizListCount);
            if (UserData.Instance.QuestionDataBeforeNum == now_index) continue;

            Debug.Log("now_index: " + now_index + " / before_index: " + UserData.Instance.QuestionDataBeforeNum);

            before_index = now_index;

            UserData.Instance.SetQuestionBeforeNum(before_index);

            Debug.Log("差し替え後　now_index: " + now_index + " / before_index: " + UserData.Instance.QuestionDataBeforeNum);
            loop = false;
        }

        QuestionAndOptions question = new QuestionAndOptions(questionsInfomation.Question[now_index] , questionsInfomation.Options1[now_index], questionsInfomation.Options2[now_index], questionsInfomation.Options3[now_index], questionsInfomation.Answer[now_index]);

        SetOptionsAndAnser(question);
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
    public void SetOptionsAndAnser(QuestionAndOptions question)
    {
        QuestionData.Instance.SetOption1(question.Option1);
        QuestionData.Instance.SetOption2(question.Option2);
        QuestionData.Instance.SetOption3(question.Option3);
        QuestionData.Instance.SetAnser(question.Answer);
    }

    /// <summary>
    /// ストーリーのテキスト表示管理
    /// </summary>
    public void ShowStoryText()
    {
        if (_textCount == talkingTextList.Count -2)
        {
            ShowOptionArea();
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
    public void SelectedAnser(string optionName)
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
            anser.GetComponentInChildren<Text>().text = optionName;

            ShowStoryText();
            // ポイントをセット
            SetTownPoint(ob.GetComponent<OptionController>().Score);
            // エリアへ戻る
            StartCoroutine(BackAreaDelay());
        }
    }

    /// <summary>
    /// 回答に合わせたスコアを保存
    /// </summary>
    /// <param name="Score"></param>
    void SetTownPoint(int Score)
    {
        Score = UserData.Instance.TownScore + Score;
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
