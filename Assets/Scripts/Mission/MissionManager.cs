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

    public ReactiveProperty<string> itemName = new ReactiveProperty<string>();
    public BoolReactiveProperty _isStayCursor = new BoolReactiveProperty();
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

        int mask = LayerMask.GetMask(new string[] { "Item" });

        //Rayの長さ
        float maxDistance = 100;

        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance, mask);

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);

        //なにかと衝突した時だけそのオブジェクトの名前をログに出す
        if (hit.collider)
        {
            Debug.Log(hit.collider.gameObject.name);
            itemName.Value = hit.collider.gameObject.name;
            _isStayCursor.Value = true;
        }

        _isStayCursor.Value = false;
    }

    void SetTownPoint()
    {
        UserData.Instance.SetTownScore(missionJudgeController.Score);
    }

    public void BackTownArea()
    {
        SceneManager.LoadScene("Town");
    }

    public void ShowDescription(String description)
    {
        sampleText.text = description;
    }
}
