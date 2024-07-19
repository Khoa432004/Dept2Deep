using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerAttack : EnemyAttack
{
    string Tag = "Enemy";
    Char_Assassin Player;
    Zombie_Script Enemy;
    bool touch = false;
    void Start()
    {
        //CheckChar(player,enemy);
        Player = GetComponent<Char_Assassin>();
        Enemy = GetComponent<Zombie_Script>();
    }
    void Update()
    {
        if (touch)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Damage();
        }
        else;
            //UnityEngine.Debug.LogWarning("Dont have enough AttackRange");
    }

    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag(Tag))
        {
            Enemy = obj.GetComponent<Zombie_Script>();
            if (Player != null && Player.AttackSpeed > 0 ) //icd
            {
                touch = true;
            }
        }
        else
        {
            UnityEngine.Debug.LogWarning("Error");
        }
    }

    public void Damage()
    {
        UnityEngine.Debug.Log(Tag + " take " + CaculateDmg());
    }
    public int CaculateDmg()
    {
        return Player.Damage - Enemy.Def;
    }
}
