using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemController : MonoBehaviour
{
    [SerializeField]
    MissionJudgeController missionJudgeController;

    [SerializeField]
    MissionManager missionManager;

    private bool _firstClick = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    /// 離した時
    /// </summary>
    private void OnMouseUp()
    {
        if (missionJudgeController.IsClear)
        {
            missionManager.ShowText();
            this.gameObject.SetActive(false);
        }
    }

    //　押された時
    private void OnMouseDown()
    {
        if (!_firstClick)
        {
            missionManager.ShowText();
            _firstClick = true;
        }
    }
}
