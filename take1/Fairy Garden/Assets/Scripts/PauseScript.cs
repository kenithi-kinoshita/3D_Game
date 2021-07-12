using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    //　停止中に表示するUI
    [SerializeField]
    private GameObject pauseUI;

    [SerializeField]
    private PlayerInput playerInput;
    private InputAction pauseAction;
    // Start is called before the first frame update
    void Start()
    {
        pauseAction = playerInput.currentActionMap.FindAction("Pause");
        //　スタート時にポーズUIを非表示にする
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //　ポーズボタンを押した時
        //if (Input.GetButtonDown("Pause"))
        if (pauseAction.triggered)
        {
            if(Mathf.Approximately(Time.timeScale, 1f))
            {
                Time.timeScale = 0f;
                pauseUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseUI.SetActive(false);
            }
        }
    }
}
