using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ItemController : MonoBehaviour
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


    [SerializeField]
    MissionManager missionManager;

    private Vector3 screenPoint;

    /*
    private BoolReactiveProperty _isStayCursor = new BoolReactiveProperty();
    public IObservable<bool> IsStayCursor
    {
        get { return _isStayCursor.Where(c => c == true); }
    }
    */

    void Start()
    {
        //TODO:
        //・3秒経ったらState.Selectにする
        /*
        missionManager.IsStayCursor.Subscribe(_ => {
            Observable.Timer(TimeSpan.FromSeconds(3))
            .Subscribe(_ =>
            {
                Debug.Log("3秒たった");
                state = State.Select;

            }).AddTo(this);
        }).AddTo(this);
        */


        //・説明文の表示をする

        /*
        missionManager.IsStayCursor.Subscribe(_ => {
            Observable.Timer(TimeSpan.FromSeconds(3))
            .First(_ => missionManager.itemName.Value == this.gameObject.name)
            .DistinctUntilChanged()
            .Subscribe(_ =>
            {
                Debug.Log("3秒たった");
                state = State.Select;
            }).AddTo(this);
        }).AddTo(this);
        */

        //ItemDescription(missionManager.itemName.Value);
    }

    private void GetItemData()
    {
        // TODO: CSVからデータ全てとってくる
    }

    /// <summary>
    /// アイテムをドラッグする
    /// </summary>
    void OnMouseDrag()
    {
        // カーソル位置を取得
        Vector3 mousePosition = Input.mousePosition;
        // カーソル位置のz座標を10に
        mousePosition.z = 10;
        // カーソル位置をワールド座標に変換
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);

        this.gameObject.transform.position = target;
    }

    /// <summary>
    /// アイテムにカーソルが合っている時にアイテムの説明文を表示
    /// </summary>
    void ItemDescription(String description)
    {
        missionManager.ShowDescription(description);
    }

    //マウスが乗った時
    void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }
}
