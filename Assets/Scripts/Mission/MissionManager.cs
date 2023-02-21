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
    Text sampleText;

    /*
    [SerializeField]
    GameObject itemPrefab;
    private GameObject cloneObject;
    */

    [SerializeField]
    private List<GameObject> cloneObjects;


    [SerializeField]
    private List<Vector3> cloneObjectTransform;

    [SerializeField]
    GameObject parent;

    [SerializeField]
    MissionJudgeController missionJudgeController;


    private BoolReactiveProperty _isStayCursor = new BoolReactiveProperty();
    public IObservable<bool> IsStayCursor
    {
        get { return _isStayCursor.Where(c => c == true); }
    }

    void Start()
    {
        // Missionが終わった場合、回答に応じてポイントをセットする
        missionJudgeController.OnMissionEnd.Subscribe(_ =>
        {
            SetTownPoint();
        }).AddTo(this);

       
    }

    private void Update()
    {
        //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //レイヤーマスク作成
        //int layerId = LayerMask.NameToLayer("Item");

        //Rayの長さ
        float maxDistance = 100;

        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);

        //なにかと衝突した時だけそのオブジェクトの名前をログに出す
        if (hit.collider)
        {
            Debug.Log(hit.collider.gameObject.name);
            _isStayCursor.Value = true;
        }
    }

    void SetTownPoint()
    {
        UserData.Instance.SetTownScore(missionJudgeController.Score);
    }

    public void BackTownArea()
    {
        SceneManager.LoadScene("Town");
    }
}
