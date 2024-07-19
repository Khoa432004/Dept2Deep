using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAttack : MonoBehaviour //Chưa OOP 
{
    string tag = "Player";
    Char_Assassin player;
    Zombie_Script enemy;

    // Start is called before the first frame update
    void Start()
    {
        //CheckChar(player,enemy);
        player = GetComponent<Char_Assassin>();
        enemy = GetComponent<Zombie_Script>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            player = collision.gameObject.GetComponent<Char_Assassin>();
            if (player != null && enemy != null && enemy.AttackSpeed > 0)
            {
                InvokeRepeating(nameof(Damage), 0, enemy.AttackSpeed);
            }
            else
            {
                Debug.LogWarning("Player or enemy component is missing, or attack speed is invalid.");
            }
        }
        else
        {
            Debug.LogWarning("Collided object is not the player.");
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            player = null;
            CancelInvoke(nameof(Damage));
        }
    }
    public void Damage()
    {
        Debug.Log(tag+ " take " + CaculateDmg());
    }
    public int CaculateDmg()
    {
        return enemy.Damage - player.Def;
    }

    public void CheckChar(Player player, Enemy enemy)
    {
        CheckPlayer(player);
        CheckEnemy(enemy);
    }
    public void CheckPlayer(Player player)
    {
        if (player is Char_Assassin)
        {
            player = GetComponent<Char_Assassin>();
            player = (Char_Assassin)player;
        }
    }
    public void CheckEnemy(Enemy enemy)
    {
        if (enemy is Char_Assassin)
        {
            enemy = GetComponent<Zombie_Script>();
            enemy = (Zombie_Script)enemy;
        }
    }
}
