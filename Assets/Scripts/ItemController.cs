using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Camera mainCamera;             //メインカメラ取得
    private float piecePosZ;               //ピースのZ座標

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        piecePosZ = transform.position.z;
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