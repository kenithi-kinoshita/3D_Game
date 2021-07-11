using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGaugeUpdateScript : MonoBehaviour
{
	//　PlayerStatus
	[SerializeField]
	private PlayerStatus playerStatus;

	// Start is called before the first frame update
	void Start()
	{
		//　ライフゲージの設定
		UpdateLifeGauge();
	}

	//　ライフゲージのアップデート
	public void UpdateLifeGauge()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			if (i < playerStatus.GetHp())
			{
				transform.GetChild(i).GetComponent<Image>().color = new Color(0f, 0f, 1f);
			}
			else
			{
				transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f);
			}
		}
	}
}