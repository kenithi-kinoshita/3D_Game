using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletScript : MonoBehaviour
{
    //　ゲームマネージャー
    private GameManager gameManager;
    //　弾のプレハブ
    [SerializeField]
    private GameObject bullet;
    //　弾を発射する間隔秒数
    [SerializeField]
    private float fireInterval = 2f;
    //　弾に加える力
    [SerializeField]
    private float power = 10f;
    //　経過時間
    private float nowTime;

    // Start is called before the first frame update
    void Start()
    {
        //　ゲームマネージャーの取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //　ゲームオーバー時は以降何もしない
        if (gameManager.IsCountDown || gameManager.GameOver)
        {
            return;
        }
        //　一定時間ごとに弾を発射
        nowTime += Time.deltaTime;
        if(nowTime >= fireInterval)
        {
            Fire();
            nowTime = 0f;
        }
    }

    void Fire()
    {
        //　弾プレハブをインスタンス化
        var ins = Instantiate(bullet, transform.position, transform.rotation);
        //　弾のRigidbodyに質量を無視して力を加える
        ins.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.Force);
    }
}
