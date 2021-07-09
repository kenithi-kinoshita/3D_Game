using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalArea : MonoBehaviour
{
    //　ゲームマネージャー
    private GameManager gameManager;
    //　ゲームクリアフラグ
    private bool gameClear;

    // Start is called before the first frame update
    void Start()
    {
        //　ゲームマネージャーの取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //　エリア内にプレイヤーが侵入したらゲームクリア
    private void OnTriggerEnter(Collider other)
    {
        if(!gameClear && other.CompareTag("Player"))
        {
            gameClear = true;
            gameManager.ClearGame();
        }
    }
}
