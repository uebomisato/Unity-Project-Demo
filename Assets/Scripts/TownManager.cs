using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownManager : MonoBehaviour
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

    bool _item1 ,_item2,_item3 = false;

    // Start is called before the first frame update
    void Start()
    {
        /*
        for (int i = 0; i < 3; i++)
        {
            cloneObject = Instantiate(itemPrefab, new Vector3(0f, 320.0f, 0f), Quaternion.identity);

            Vector3 hoge = new Vector3(0f, cloneObject.transform.position.y - 100f, 0.0f);
            cloneObject.transform.parent = parent.transform; // GameManagerを親に指定
            cloneObject.transform.position = hoge;

            cloneObjects.Add(cloneObject);
        }
        */

        /*
        for (int i = 0; i < cloneObjects.Count; i++)
        {
            cloneObjectTransform[i] = cloneObjects[i].transform.position;
        }
        */

        //cloneObject.transform.position = new Vector3(-1.0f, 1.0f, 0.0f); // 座標を変更
    }

    // Update is called once per frame
    void Update()
    {
        
        // カーソル位置を取得
        Vector3 mousePosition = Input.mousePosition;
        // カーソル位置のz座標を10に
        mousePosition.z = 10;
        // カーソル位置をワールド座標に変換
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
        //オブジェクトの座標を変更する

        if (_item1)
        {
            cloneObjects[0].transform.position = target;
            cloneObjects[1].transform.localPosition = cloneObjectTransform[1];
            cloneObjects[2].transform.localPosition = cloneObjectTransform[2];
        }
        if(_item2)
        {
            cloneObjects[1].transform.position = target;
            cloneObjects[0].transform.localPosition = cloneObjectTransform[0];
            cloneObjects[2].transform.localPosition = cloneObjectTransform[2];
        }
        if (_item3)
        {
            cloneObjects[2].transform.position = target;
            cloneObjects[0].transform.localPosition = cloneObjectTransform[0];
            cloneObjects[1].transform.localPosition = cloneObjectTransform[1];
        }


        if (Input.GetKey(KeyCode.U))
        {
            _item1 = true;
            _item2 = false;
            _item3 = false;
        }
        else if (Input.GetKey(KeyCode.I))
        {
            _item1 = false;
            _item2 = true;
            _item3 = false;
        }
        else if (Input.GetKey(KeyCode.O))
        {
            _item1 = false;
            _item2 = false;
            _item3 = true;
        }

        //sampleText.text = gameObjectTransform.position.ToString();

    }

    /// <summary>
    /// 動いてない
    /// </summary>
    /*
    void OnMouseDrag()
    {
        Debug.Log("テスト");
        
        //Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        

        //マウスカーソル及びオブジェクトのスクリーン座標を取得
        Vector3 objectScreenPoint =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        //スクリーン座標をワールド座標に変換
        Vector3 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);

        //オブジェクトの座標を変更する
        gameObjectTransform.position = objectWorldPoint;

        sampleText.text = gameObjectTransform.position.ToString();
    }
    */
}
