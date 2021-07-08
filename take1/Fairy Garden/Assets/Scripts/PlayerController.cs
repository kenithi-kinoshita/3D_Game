using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour
{

    //　Rigidbodyコンポーネント
    private Rigidbody rigidBody;
    //　キャラクターのコライダ
    private CapsuleCollider myCollider;
    //　入力値
    private Vector3 input;
    //　移動速度
    private Vector3 velocity;
    //　設置しているかどうか
    [SerializeField]
    private bool isGrounded;
    //　移動の速さ
    [SerializeField]
    private float moveSpeed = 2f;
    //　アニメーションパラメーターを操作する
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //　設置確認
        CheckGround();
        // 移動速度の計算
        Move();
    }

    //　地面のチェック
    private void CheckGround()
    {
        if (isGrounded)
        {
            return;
        }
        //　GroundまたはEnemyレイヤーと球のコライダがぶつかった場合は地面に接地
        if (Physics.CheckSphere(rigidBody.position, myCollider.radius - 0.1f, LayerMask.GetMask("Ground")))
        {
            isGrounded = true;
            velocity.y = 0f;
        }
        else
        {
            isGrounded = false;
                }

    }
    //　移動値と向きの計算
    private void Move()
    {
       //　接地している場合
       if (isGrounded)
        {
            //　移動速度の長さが0より大きければ歩くアニメーション
            if (velocity.magnitude > 0f)
            {
                animator.SetFloat("Speed", velocity.magnitude);
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }
            //　移動速度を初期化
            velocity = Vector3.zero;
        }
        //　移動入力値
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //　速度の計算
        velocity = new Vector3(input.normalized.x * moveSpeed, 0f, input.normalized.z * moveSpeed);
    }
    //　ギズモの表示
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //　接地判断時の範囲表示
        Gizmos.DrawLine(transform.position + Vector3.up * 0.1f, transform.position + Vector3.down * 0.2f);
    }
    //　固定フレームレートで実行される
    private void FixedUpdate()
    {
        //　入力がある時だけ実行
        if (!Mathf.Approximately(input.x, 0f) || !Mathf.Approximately(input.z, 0f))
        {
            rigidBody.MoveRotation(Quaternion.LookRotation(input.normalized));
        }
        ////　入力がある時だけ実行
        //if(input.magnitude > 0f)
        //{
        //    //　入力方向にむける
        //    rigidBody.MoveRotation(Quaternion.LookRotation(input.normalized));
        //}

        //　現在の位置に1フレームの速度分を足して移動させる
        if(velocity.magnitude > 0f)
        {
            rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        }
    }



}

