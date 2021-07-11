using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "CreatePlayerStatus")]
public class PlayerStatus : ScriptableObject
{
    [SerializeField]
    private int hp;

    public int SetHP(int hp)
    {
        if(hp <= 0)
        {
            hp = 0;
        }
        this.hp = hp;
        return this.hp;
    }
    public int GetHp()
    {
        return this.hp;
    }
    public void Reset()
    {
        this.hp = 10;
    }
}
