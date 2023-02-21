using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Triggers;
using UniRx;
using UnityEngine.SceneManagement;

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
    MissionController missionController;

    // Start is called before the first frame update
    void Start()
    {
        // Missionが終わった場合、回答に応じてポイントをセットする
        missionController.OnMissionEnd.Subscribe(_ =>
        {
            SetTownPoint();
            
        }).AddTo(this);
    }

    void Update()
    {
        
    }

    void SetTownPoint()
    {
        UserData.Instance.SetTownScore(missionController.Score);
    }

    public void BackTownArea()
    {
        SceneManager.LoadScene("Town");
    }
}
