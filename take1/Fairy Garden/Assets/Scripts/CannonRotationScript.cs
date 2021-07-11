
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotationScript : MonoBehaviour
{
	//　砲身を回転させるかどうか
	[SerializeField]
	private bool rotatable;
	//　回転スピード
	[SerializeField]
	private float rotationSpeed = 2f;
	private Transform player;

	private Rigidbody rigidBody;
	//　砲身が向く角度
	private Quaternion viewingQuaternion;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindWithTag("Player").transform;
		rigidBody = GetComponent<Rigidbody>();
		viewingQuaternion = Quaternion.identity;
	}

	// Update is called once per frame
	void Update()
	{
		if (rotatable)
		{
			//　徐々に砲身をプレイヤーの方向に向ける為の処理
			viewingQuaternion = Quaternion.Slerp(rigidBody.rotation, Quaternion.LookRotation(player.position - rigidBody.position + Vector3.up * 0.8f), rotationSpeed * Time.deltaTime);
		}
	}

	private void FixedUpdate()
	{
		//　砲身の根元を回転させる
		if (rotatable)
		{
			rigidBody.MoveRotation(viewingQuaternion);
		}
	}
}
