using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //　ゲームオーバーかどうか
    public bool GameOver
    {
        get; set;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
