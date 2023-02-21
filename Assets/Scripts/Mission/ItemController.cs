using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    /*
     * Itemが持つ要素
     * 
     * ・アイテム名 (CSVから取得)
     * ・アイテム画像
     * ・現在の状態 (選択中・かざしている・何もない)
     * ・初期位置
     * 
     * ------------
     * 
     * TODO:
     * ・Itemクラス作る
     */

    private Vector3 screenPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void GetItemData()
    {
        // TODO: CSVからデータ全てとってくる
    }

    /*
    //ドラッグ処理
    private void OnMouseDrag()
    {
        //マウスのポジションを取得してピースZ座標を代入しておく
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = piecePosZ;

        //ドラッグ中のピースにマウス座標を代入する
        transform.position = mousePos;
    }
    */

    /// <summary>
    /// 動いてない
    /// </summary>

    void OnMouseDrag()
    {
        // カーソル位置を取得
        Vector3 mousePosition = Input.mousePosition;
        // カーソル位置のz座標を10に
        mousePosition.z = 10;
        // カーソル位置をワールド座標に変換
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);


        //Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        this.gameObject.transform.position = target;
        //Debug.Log("target: " + target);
    }
}
