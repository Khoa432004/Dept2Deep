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
        else
            UnityEngine.Debug.LogWarning("Dont have enough AttackRange");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tag))
        {
            Enemy = collision.gameObject.GetComponent<Zombie_Script>();
            if (Player != null && Player.AttackSpeed > 0) // Check for valid attack speed
            {
                touch = true;
            }
        }
        else
        {
            UnityEngine.Debug.LogWarning("Error");
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tag))
        {
            touch = false;
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