using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UserData
{
    // ホリバリアンランク
    public enum Rank
    {
        Lowest = 0,
        Low = 3,
        Medium = 6,
        High = 7,
        Highest = 8,
    }

    static UserData data;
    public static UserData Instance
    {
        get
        {
            if (data == null)
            {
                data = new UserData();
            }
            return data;
        }
    }


    CompositeDisposable disposeBag;

    /// <summary>
    /// 各エリア スコア保持用
    /// </summary>
    IntReactiveProperty townScore = new IntReactiveProperty(0);
    public int TownScore { get { return townScore.Value; } }

    IntReactiveProperty houseScore = new IntReactiveProperty(0);
    public int HouseScore { get { return houseScore.Value; } }

    IntReactiveProperty natureScore = new IntReactiveProperty(0);
    public int NatureScore { get { return natureScore.Value; } }


    IntReactiveProperty questionDataBeforeNum = new IntReactiveProperty(0);
    public int QuestionDataBeforeNum { get { return questionDataBeforeNum.Value; } }


    /// <summary>
    /// コンストラクタ
    /// </summary>
    UserData()
    {
        disposeBag = new CompositeDisposable();
    }
    /// <summary>
    /// デストラクタ (Object削除した時に動く)
    /// </summary>
    ~UserData()
    {
        disposeBag.Dispose();
    }


    /// <summary>
    /// 各エリアでのスコアセット
    /// </summary>
    public void SetTownScore(int score)
    {
        this.townScore.Value = score;
    }

    public void SetHouseScore(int score)
    {
        this.houseScore.Value = score;
    }

    public void SetNatureScore(int score)
    {
        this.natureScore.Value = score;
    }

    public void SetQuestionBeforeNum(int num)
    {
        this.questionDataBeforeNum.Value = num;
    }
}
