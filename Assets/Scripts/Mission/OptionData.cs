using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class OptionData
{
    public int id;
    public string option;
    public int missionId;
    public string anserRank;
    public int score;

    //コンストラクタ
    public OptionData(int id, string option, int missionId, string anserRank, int score)
    {
        //自分のクラスのメンバーに引数の値を代入する
        //this.〇〇とすることで引数とメンバーを区別することができる
        this.id = id;
        this.option = option;
        this.missionId = missionId;
        this.anserRank = anserRank;
        this.score = score;
    }

    public OptionData()
    {
        //自分のクラスのメンバーに引数の値を代入する
        //this.〇〇とすることで引数とメンバーを区別することができる
        this.id = 1;
        this.option = "サンプル選択肢";
        this.missionId = 1;
        this.anserRank = "大正解";
        this.score = 10000;
    }
}
