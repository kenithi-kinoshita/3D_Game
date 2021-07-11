using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	private GameManager gameManager;
	private NavMeshAgent navMeshAgent;
	private Transform player;
	private Animator animator;
	//　キャラクターを操作可能かどうか
	private bool canControl;
	[SerializeField]
	private int attackPower = 2;
	private PlayerController playerController;

	// Start is called before the first frame update
	void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		player = GameObject.Find("Player").transform;
		animator = GetComponent<Animator>();
		canControl = true;
		player = GameObject.Find("Player").transform;
		playerController = player.GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!canControl)
		{
			return;
		}
		//　ゲームオーバー時は停止してこれ以降何もしない
		if (gameManager.GameOver)
		{
			navMeshAgent.isStopped = true;
			animator.SetFloat("Speed", 0f);
			canControl = false;
			return;
		}
		//　目的地の再設定
		navMeshAgent.SetDestination(player.position);

		//　プレイヤーキャラクターと敵キャラクターの距離
		var characterDistance = Vector2.Distance(new Vector2(player.position.x, player.position.z), new Vector2(transform.position.x, transform.position.z));
		//　止まっている時
		if (navMeshAgent.isStopped)
		{
			//　距離が開いたら再度追いかける（Y軸は無視）
			if (characterDistance > 2f)
			{
				navMeshAgent.isStopped = false;
			}
		}
		else
		{
			//　目的地との距離が開いている場合
			if (characterDistance > 0.8f)
			{
				navMeshAgent.isStopped = false;
				animator.SetFloat("Speed", navMeshAgent.speed);
			}
			else
			{
				navMeshAgent.isStopped = true;
				animator.SetFloat("Speed", 0f);
				//　プレイヤーに近づいたのでダメージを与える
				playerController.TakeDamage(attackPower);
			}
		}
	}
}