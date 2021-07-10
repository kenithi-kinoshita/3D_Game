using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseObstacle : MonoBehaviour
{
    //　無効化するゲームオブジェクト
    [SerializeField]
    private GameObject objectOfErase;

    private void OnTriggerEnter(Collider other)
    {
        //　プレイヤーが侵入したら設定したゲームオブジェクトを無効化
        if (other.CompareTag("Player"))
        {
            //　指定したゲームオブジェクトの効果処理を実行する
            objectOfErase.GetComponent<EffectScript>().AddEffect();
            Destroy(gameObject);
        }
    }
}
