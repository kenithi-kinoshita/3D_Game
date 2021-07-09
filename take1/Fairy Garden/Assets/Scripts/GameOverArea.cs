using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverArea : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    //　何らかの古来だが侵入してきら実行
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.EndGame();
        }
    }
}
