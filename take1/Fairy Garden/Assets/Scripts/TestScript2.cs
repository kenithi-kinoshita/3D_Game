using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript2 : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		int a = -6;
		//　Addメソッドの結果をresult変数に代入
		int result = Add(4, a);
		if (result >= 0)
		{
			Debug.Log("0以上");
		}
		else
		{
			Debug.Log("0未満");
		}
		//　繰り返す回数
		int numberOfTimes = 3;
		//　whileのテスト
		while (true)
		{
			Debug.Log("whileテスト " + numberOfTimes);
			numberOfTimes--;
			//　numberOfTimesが0になったらbreakでwhileループを抜ける
			if (numberOfTimes == 0)
			{
				break;
			}
		}
		//　繰り返し回数を3に設定
		numberOfTimes = 3;
		//　forのテスト
		for (int i = 0; i < numberOfTimes; i++)
		{
			Debug.Log("forテスト " + i);
		}

		string outputString = "文字列";
		// foreachのテスト
		foreach (var character in outputString)
		{
			Debug.Log("foreachテスト " + character);
		}

		//　繰り返し回数を3に設定
		numberOfTimes = 3;

		do
		{
			numberOfTimes--;
			//　偶数であればcontinueですぐに次のループに飛ばす
			if (numberOfTimes % 2 == 0)
			{
				continue;
			}
			//　numberOfTimesを表示
			Debug.Log("do-whileテスト " + numberOfTimes);
			//　numberOfTimesが-1になったらbreakでループを抜ける
			if (numberOfTimes == -1)
			{
				break;
			}
		} while (true);
	}

	//　受け取った引数を足すメソッド
	//　引数のaはStartメソッド内の変数のaとは別物
	public int Add(int a, int b)
	{
		int c = a + b;
		return c;
	}
}