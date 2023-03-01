using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadCSVSceneManager : MonoBehaviour
{
    private QuestionsInfomation questionsInfomation;

    //[SerializeField]
    //Text QuestionsText, options1, options2, options3 , Answer;

    int before_index = 0;
    int now_index;

    // Start is called before the first frame update
    void Start()
    {
        init();
        //GetQuestion();
    }

    internal static void LoadScene(string v)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init()
    {
        questionsInfomation = new QuestionsInfomation();
        questionsInfomation.Init();
    }

    public void GetQuestion()
    {
        List<string[]> csvDataList = questionsInfomation.QuizList;
        int quizListCount = csvDataList.Count;

        bool loop = true;
        while (loop)
        {
            now_index = Random.Range(1, quizListCount);
            if (before_index == now_index) continue;
            before_index = now_index;
            loop = false;
        }

        //QuestionsText.text = "問題 : " + questionsInfomation.Question[now_index];
        //options1.text = "選択肢1 : " + questionsInfomation.options1[now_index];
        //options2.text = "選択肢2 : " + questionsInfomation.options2[now_index];
        //options3.text = "選択肢3 : " + questionsInfomation.options3[now_index];
        //Answer.text = "答え : " + questionsInfomation.Answer[now_index];
    }


    public QuestionsInfomation GetQuestions()
    {
        List<string[]> csvDataList = questionsInfomation.QuizList;
        int quizListCount = csvDataList.Count;

        bool loop = true;
        while (loop)
        {
            now_index = Random.Range(1, quizListCount);
            if (before_index == now_index) continue;
            before_index = now_index;
            loop = false;
        }

        return questionsInfomation;
        //QuestionsText.text = "問題 : " + questionsInfomation.Question[now_index];
        //options1.text = "選択肢1 : " + questionsInfomation.options1[now_index];
        //options2.text = "選択肢2 : " + questionsInfomation.options2[now_index];
        //options3.text = "選択肢3 : " + questionsInfomation.options3[now_index];
        //Answer.text = "答え : " + questionsInfomation.Answer[now_index];
    }
}
