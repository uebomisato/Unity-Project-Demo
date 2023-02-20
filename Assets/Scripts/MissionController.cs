using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    private string itemTag = "Item";
    [SerializeField]
    BoxCollider2D characterCollider;
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
            Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);

            // TODO:
            // csvデータの「回答」絡むの文字と一致したら正解判定にする
            if (other.gameObject.name == "item")
            {
                Debug.Log("正解！");

            }
        }
    }
}
