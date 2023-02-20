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
}
