using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour
{

	private CharacterController enemyController;
	private Animator animator;
	//　目的地
	private Vector3 destination;
	//　歩くスピード
	[SerializeField]
	private float walkSpeed = 1.0f;
	//　速度
	private Vector3 velocity;
	//　移動方向
	private Vector3 direction;
	//　到着フラグ
	private bool arrived;
	//　スタート位置
	private Vector3 startPosition;


	// Use this for initialization
	void Start()
	{
		enemyController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		var randDestination = Random.insideUnitCircle * 8;
		destination = startPosition + new Vector3(randDestination.x, 0, randDestination.y);
		velocity = Vector3.zero;
		arrived = false;
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (!arrived)
		{
			if (enemyController.isGrounded)
			{
				velocity = Vector3.zero;
				animator.SetFloat("Speed", 2.0f);
				direction = (destination - transform.position).normalized;
				transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
				velocity = direction * walkSpeed;
				//Debug.Log(destination);
			}
			velocity.y += Physics.gravity.y * Time.deltaTime;
			enemyController.Move(velocity * Time.deltaTime);

			//　目的地に到着したかどうかの判定
			if (Vector3.Distance(transform.position, destination) < 0.5f)
			{
				arrived = true;
				animator.SetFloat("Speed", 0.0f);
			}
		}
	}
}