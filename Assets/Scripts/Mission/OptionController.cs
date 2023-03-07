using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    /*
     * Itemが持つ要素
     * 
     * ・アイテム名 (CSVから取得)
     * ・アイテムの説明文 (かざしている時に表示)
     * ・アイテム画像
     * ・現在の状態 (選択中・かざしている・何もない)
     * ・初期位置
     * 
     * ------------
     * 
     * TODO:
     * ・Itemクラス作る
     */

    enum State {
        None, 　// 何もしていない
        Select, // 選択された
        Pick    // 摘む
    }

    State state = State.None;

    float time = 0.0f;
    public static bool beingMeasured; // 計測中であることを表す変数
    private bool isMoving;

    [SerializeField]
    MissionManager missionManager;


    //string _optionName;
    //public string OptionName
    //{
    //    get { return _optionName; }
    //}

    [SerializeField]
    int _score;
    public int Score
    {
        get { return _score; }
    }

    /*
    [SerializeField]
    GameObject hukidashi;
    */

    [SerializeField]
    int optionId;

    [SerializeField]
    Text optionName;

    private String description;

    bool _isSelected = false;
    public bool IsSelected
    {
        get { return _isSelected; }
    }



    void Start()
    {
        _isSelected = false;
        beingMeasured = false;
        isMoving = false;
        //hukidashi.SetActive(false);
        description = this.gameObject.name + "の説明文です！";
    }

    private void Update()
    {
        if (!beingMeasured)
        {
            time = 0.0f;
        }
        time += Time.deltaTime;
    }

    public void GetItemData()
    {
        if (optionId == 1)
        {
            optionName.text = QuestionData.Instance.Option1;
            //Debug.Log(QuestionData.Instance.Option1);
        }
        else if (optionId == 2)
        {
            optionName.text = QuestionData.Instance.Option2;
            //Debug.Log(QuestionData.Instance.Option2);
        }
        else if (optionId == 3)
        {
            optionName.text = QuestionData.Instance.Option3;
            //Debug.Log(QuestionData.Instance.Option3);
        }
    }

    /// <summary>
    /// アイテムをドラッグする
    /// </summary>
    //void OnMouseDrag()
    //{
    //    isMoving = true;
    //    beingMeasured = false;
    //    //HideItemDescription();
    //    // カーソル位置を取得
    //    Vector3 mousePosition = Input.mousePosition;
    //    // カーソル位置のz座標を10に
    //    mousePosition.z = 10;
    //    // カーソル位置をワールド座標に変換
    //    Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);

    //    this.gameObject.transform.position = target;
    //}

    /// <summary>
    /// アイテムにカーソルが合っている時にアイテムの説明文を表示
    /// </summary>
    /// 
    //public void ItemDescription(String description)
    //{
    //    //hukidashi.GetComponentInChildren<Text>().text = description;
    //}

    //public void HideItemDescription()
    //{
    //    //hukidashi.SetActive(false);
    //}


    /// <summary>
    /// アイテムにカーソルを2秒以上置いていた時にアイテムの説明文を表示
    /// </summary>
    void OnMouseOver()
    {
        beingMeasured = true;

        if (time >= 3.0f && !isMoving)
        {
            beingMeasured = false;
            //time = 0f;
            //hukidashi.SetActive(true);
            //ItemDescription("アイテム名: " + this.gameObject.name + " / 説明文: 説明文説明文説明文説明文説明文説明文説明文");
            _isSelected = true;
            missionManager.SelectedAnser(optionName.text);
        }
    }

    /// <summary>
    /// アイテムからカーソルが離れた時にアイテムの説明文を非表示
    /// </summary>
    void OnMouseExit()
    {
        beingMeasured = false;
        isMoving = false;
        //hukidashi.SetActive(false);
    }

}
