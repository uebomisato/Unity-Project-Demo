using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QuestionsInfomation
{
    static TextAsset csvFile; // CSVファイル
    static List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;
    public List<string[]> QuizList
    {
        get { return csvDatas; }
    }

    public string[] Question = new string[100];
    public string[] Options1 = new string[100];
    public string[] Options2 = new string[100];
    public string[] Options3 = new string[100];
    public string[] Answer = new string[100];

    static void CsvReader()
    {
        csvFile = Resources.Load("Questions") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

        // csvDatas[行][列]を指定して値を自由に取り出せる
        //Debug.Log(csvDatas[0][1]);
    }

    public void Init()
    {
        CsvReader();//enemyDataへ情報を一時格納
        //各変数へデータを格納
        for (int i = 1; i < csvDatas.Count; i++)//エネミーIDが記述された最後まで読み込み。一行目はタイトルなのでi=0はデータとして扱わない
        {
            
            Question[i] = csvDatas[i][0];
            Options1[i] = csvDatas[i][1];
            Options2[i] = csvDatas[i][2];
            Options3[i] = csvDatas[i][3];
            Answer[i] = csvDatas[i][4];  
        }
    }

    public QuestionAndOptions hoge()
    {
        CsvReader();//enemyDataへ情報を一時格納

        var hoge = new QuestionAndOptions();

        //各変数へデータを格納
        for (int i = 1; i < csvDatas.Count; i++)//エネミーIDが記述された最後まで読み込み。一行目はタイトルなのでi=0はデータとして扱わない
        {
            hoge.Question = csvDatas[i][0];
            hoge.Option1 = csvDatas[i][1];
            hoge.Option2 = csvDatas[i][2];
            hoge.Option3 = csvDatas[i][3];
            hoge.Answer = csvDatas[i][4];
        }

        return hoge;
    }
}
