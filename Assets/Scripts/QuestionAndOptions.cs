using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAndOptions
{
    public string Question;
    public string Option1;
    public string Option2;
    public string Option3;
    public string Answer;

    //コンストラクタ
    public QuestionAndOptions(string question, string option1, string option2, string option3,string answer)
    {
        //自分のクラスのメンバーに引数の値を代入する
        //this.〇〇とすることで引数とメンバーを区別することができる
        this.Question = question;
        this.Option1 = option1;
        this.Option2 = option2;
        this.Option3 = option3;
        this.Answer = answer;
    }

    public QuestionAndOptions()
    {
        //自分のクラスのメンバーに引数の値を代入する
        //this.〇〇とすることで引数とメンバーを区別することができる
        this.Question = "TestQuestion";
        this.Option1 = "TestOption1";
        this.Option2 = "TestOption2";
        this.Option3 = "TestOption3";
        this.Answer = "TestAnser";
    }
}
