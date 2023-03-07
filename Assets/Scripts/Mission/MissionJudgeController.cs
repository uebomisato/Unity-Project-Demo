using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MissionJudgeController : MonoBehaviour
{
    private string itemTag = "Item";
    private string tutorialItemTag = "Instrument";

    [SerializeField]
    BoxCollider2D characterCollider;

    //int _score = 0;
    //public int Score
    //{
    //    get { return _score; }
    //}

    bool _isClear;
    public bool  IsClear
    {
        get { return _isClear; }
    }


    // Start is called before the first frame update
    void Start()
    {
        _isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        Debug.Log("持ってきたアイテム名: " + other.gameObject.name);

        if (other.gameObject.CompareTag(itemTag))
        {
            // TODO:
            // csvデータの「回答」絡むの文字と一致したら正解判定にする
            if (other.gameObject.name == "item1")
            {
                Debug.Log("正解だよ！");
                Debug.Log("------------------------------");
                _score += 1;

            }
            else
            {
                Debug.Log("違うアイテムを選んでね");
                Debug.Log("------------------------------");
            }
        }
        */
        if (other.gameObject.CompareTag(tutorialItemTag))
        {
            _isClear = true;
            Debug.Log("_isClear: " + _isClear);
        }
    }
}
