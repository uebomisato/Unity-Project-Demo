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
    [SerializeField]
    private List<GameObject> cloneObjects;


    [SerializeField]
    private List<Vector3> cloneObjectTransform;

    [SerializeField]
    GameObject parent;

    [SerializeField]
    MissionJudgeController missionJudgeController;

    [SerializeField]
    List<String> talkingTextList;

    [SerializeField]
    Text charactorText;

    Dictionary<int, string> dic = new Dictionary<int, string>();

    int _textCount = 0;


    public static bool beingMeasured; // 計測中であることを表す変数

    void Start()
    {

    }

    private void Update()
    {
        // 右ボタンが押された瞬間に実行
        if (Input.GetKeyDown(KeyCode.N))
        {
            ShowText();
        }
    }


    void SetTownPoint()
    {
        UserData.Instance.SetTownScore(missionJudgeController.Score);
    }

    public void BackTownArea()
    {
        SetTownPoint();
        SceneManager.LoadScene("Town");
    }

    public void ShowText()
    {
        charactorText.text = talkingTextList[_textCount];
        //Debug.Log("テキスト: " + talkingTextList[_textCount]);
        _textCount += 1;
    }

}
