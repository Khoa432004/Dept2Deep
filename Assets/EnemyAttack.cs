using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAttack : MonoBehaviour
{
    string tag = "Player";
    Char_Assassin player;
    Zombie_Script enemy;

    private void Start()
    {
        player = GetComponent<Char_Assassin>();
        enemy = GetComponent<Zombie_Script>();
        Update();
    }

    private void Update()
    {
        if (player != null)
        {
            player.healthBar.UpdateBar(player.CurrentHealth, player.Health);
            player.manaBar.UpdateBar(player.CurrentMana, player.Mana);
        }
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
        if(player.CurrentHealth <= 0)
        {
            Destroy(player);  
        }
        else
        player.CurrentHealth -= CaculateDmg();
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
            player = (Char_Assassin)player;
            player = GetComponent<Char_Assassin>();
        }
    }
    public void CheckEnemy(Enemy enemy)
    {
        if (enemy is Char_Assassin)
        {
            enemy = (Zombie_Script)enemy;
            enemy = GetComponent<Zombie_Script>();
        }
    }
}
