using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private int attackPower = 1;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // 弾が発生して10秒後に消す
        Destroy(gameObject, 10f);
        return;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameManager.GameOver)
        {
            Destroy(gameObject);
            return;
        }
        //　衝突した相手がプレイヤーならダメージを与え、さらに力を加えて飛ばす
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(attackPower);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 5f, ForceMode.VelocityChange);
        }
        //　何らかのゲームオブジェクトに衝突したら消す
        Destroy(gameObject);
    }
}