using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class QuestionData
{
    static QuestionData data;
    public static QuestionData Instance
    {
        get
        {
            if (data == null)
            {
                data = new QuestionData();
            }
            return data;
        }
    }

    CompositeDisposable disposeBag;

    /// <summary>
    /// 各エリア スコア保持用
    /// </summary>
    StringReactiveProperty option1 = new StringReactiveProperty();
    public string Option1 { get { return option1.Value; } }

    StringReactiveProperty option2 = new StringReactiveProperty();
    public string Option2 { get { return option2.Value; } }

    StringReactiveProperty option3 = new StringReactiveProperty();
    public string Option3 { get { return option3.Value; } }

    StringReactiveProperty anser = new StringReactiveProperty();
    public string Anser { get { return anser.Value; } }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    QuestionData()
    {
        disposeBag = new CompositeDisposable();
    }
    /// <summary>
    /// デストラクタ (Object削除した時に動く)
    /// </summary>
    ~QuestionData()
    {
        disposeBag.Dispose();
    }

    /// <summary>
    /// 各エリアでのスコアセット
    /// </summary>
    public void SetOption1(string score)
    {
        this.option1.Value = score;
    }

    public void SetOption2(string score)
    {
        this.option2.Value = score;
    }

    public void SetOption3(string score)
    {
        this.option3.Value = score;
    }

    public void SetAnser(string score)
    {
        this.anser.Value = score;
    }
}


