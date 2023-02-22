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
    private List<GameObject> cloneObjects;


    [SerializeField]
    private List<Vector3> cloneObjectTransform;

    [SerializeField]
    GameObject parent;

    [SerializeField]
    MissionJudgeController missionJudgeController;

    public static bool beingMeasured; // 計測中であることを表す変数

    void Start()
    {

    }

    private void Update()
    {
 
    }

    void SetTownPoint()
    {
        UserData.Instance.SetTownScore(missionJudgeController.Score);
    }

    public void BackTownArea()
    {
        SetTownPoint();
        SceneManager.LoadScene("Town");
    }

}
