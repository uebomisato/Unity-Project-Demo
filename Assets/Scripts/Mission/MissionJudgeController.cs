using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MissionJudgeController : MonoBehaviour
{
    private string itemTag = "Item";

    [SerializeField]
    BoxCollider2D characterCollider;

    int _score = 0;
    public int Score
    {
        get { return _score; }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(itemTag))
        {
            Debug.Log("持ってきたアイテム名: " + other.gameObject.name);

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
    }
}
