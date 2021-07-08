using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	private Human taro;
	private Human hanako;

	// Start is called before the first frame update
	void Start()
	{
		taro = new Human(20, "太郎");
		hanako = new Human(18, "花子");

		Debug.Log(taro.GetAge());
		Debug.Log(hanako.GetAge());

		taro.SetAge(19);
		//　Nameプロパティのsetはprivateに指定したのでこれは出来ない
		//taro.Name = "次郎";
		//　静的メソッドの呼び出し
		Human.SetTest();
		Debug.Log(Human.GetTest());
	}

	// privateなHumanクラス
	private class Human
	{
		//　年齢フィールド
		private int age;
		//　静的なtestフィールド
		private static string test;
		//　名前プロパティ
		public string Name { get; private set; }

		//　インスタンス化した時に呼ばれるコンストラクタ
		public Human(int age, string name)
		{
			this.age = age;
			Name = name;
		}

		// ageのセッター
		public void SetAge(int age)
		{
			this.age = age;
		}
		// ageのゲッター
		public int GetAge()
		{
			return age;
		}
		//　静的なセッターメソッド
		public static void SetTest()
		{
			test = "テスト";
		}
		//　静的なゲッターメソッド
		public static string GetTest()
		{
			return test;
		}
	}
}