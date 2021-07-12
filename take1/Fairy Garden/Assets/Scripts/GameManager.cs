﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameManagementData gameManagementData;
    [SerializeField]
    private PlayerStatus playerStatus;
    //　カウントダウン中かどうか
    public bool IsCountDown { get; set; }
    //　カウントダウン数字を表示するテキスト
    private TextMeshProUGUI countDownText;
    //　ゲームオーバーかどうか
    public bool GameOver { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //　ゲーム関連初期化
        GameOver = false;
        IsCountDown = true;

        if (SceneManager.GetActiveScene().name != "Title")
        {
            countDownText = GameObject.Find("CountDownText").GetComponent<TextMeshProUGUI>();
            StartCoroutine(CountDown());
        }
        else
        {
            //　タイトルシーンの時はステージ番号を1にする
            gameManagementData.StageNum = 1;
        }

        //　カウントダウン表示
        IEnumerator CountDown()
        {
            //　ステージ名の表示
            countDownText.text = SceneManager.GetActiveScene().name;
            //　ここから1秒経過毎に数字を更新
            yield return new WaitForSeconds(1f);
            countDownText.text = "3";
            yield return new WaitForSeconds(1f);
            countDownText.text = "2";
            yield return new WaitForSeconds(1f);
            countDownText.text = "1";
            yield return new WaitForSeconds(1f);
            countDownText.text = "Start";
            IsCountDown = false;
            yield return new WaitForSeconds(0.5f);
            countDownText.gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        playerStatus.Reset();
        SceneManager.LoadScene("Stage1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //　ゲームクリア時に実行する
    public void ClearGame()
    {
        GameOver = true;
    }

    //　ゲームをクリア出来なかった時に実行する
    public void EndGame()
    {
        GameOver = true;
    }
}
