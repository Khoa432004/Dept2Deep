using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAttack : MonoBehaviour
{
    new readonly string tag = "Player";
    Char_Assassin player;
    Zombie_Script enemy;
    private GameObject LogicManager;
    private LogicManager LogicManagerScript;

    private void Start()
    {
        player = GetComponent<Char_Assassin>();
        enemy = GetComponent<Zombie_Script>();
        LogicManager = GameObject.FindGameObjectWithTag("LogicGame");
        LogicManagerScript = LogicManager.GetComponent<LogicManager>();
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
            CancelInvoke(nameof(Damage));
            player = null;
        }
    }
    public void Damage()
    {
        if (player == null || enemy == null) return;

        if (player.CurrentHealth < 0)
        {
            player.gameObject.SetActive(false);
            LogicManagerScript.GameEnd();
        }
        else
        {
            player.CurrentHealth = Mathf.Max(0, player.CurrentHealth - (enemy.Damage - player.Def));
            Update();
            if (player.CurrentHealth == 0)
            {
                player.gameObject.SetActive(false);
                LogicManagerScript.GameEnd();
            }
        }
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