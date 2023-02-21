using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TownManager : MonoBehaviour
{
    [SerializeField]
    Text nowPointText;

    // Start is called before the first frame update
    void Start()
    {
        nowPointText.text = "現在の所持ポイント数 : " + UserData.Instance.TownScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMissionButton()
    {
        SceneManager.LoadScene("Mission");
    }
}
