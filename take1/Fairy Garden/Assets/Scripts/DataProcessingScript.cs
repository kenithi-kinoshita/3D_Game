using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataProcessingScript
{

    //　最高タイムの保存
    public static void SaveData(string stageName, int seconds)
    {
        if (PlayerPrefs.HasKey(stageName))
        {
            //すでに記録がある場合は以前の記録より早い場合のみ保存
            if (seconds < PlayerPrefs.GetInt(stageName))
            {
                PlayerPrefs.SetInt(stageName, seconds);
            }
        }
    }
    //　最高タイムの読み込み
    public static int LoadData(string stageName)
    {
        return PlayerPrefs.GetInt(stageName, int.MaxValue);
    }

    //　データの削除
    public static void DeleteData(string stageName)
    {
        //　データがある場合はそのデータを削除
        if (PlayerPrefs.HasKey(stageName))
        {
            //　PlayerPrefs.DeleteAllは絶対に使わない！！（Unityの設定ファイルも消える可能性あり）
            PlayerPrefs.DeleteKey(stageName);
        }
    }
}
