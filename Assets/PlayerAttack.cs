using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerAttack : EnemyAttack
{
    new readonly string tag = "Enemy";
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
        //else
        //    UnityEngine.Debug.LogWarning("Dont have enough AttackRange");
    }
    public new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
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

    public new void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            touch = false;
        }
    }

    private new void Damage()
    {
        if (Enemy == null) return;

        if (Enemy.CurrentHealth <= 0)
        {
            Destroy(Enemy.gameObject); // Hủy GameObject của enemy thay vì chỉ component
            Enemy = null;
            touch = false;
        }
        else
        {
            Enemy.CurrentHealth = Mathf.Max(0, Enemy.CurrentHealth - (Player.Damage - Enemy.Def));
            Player.CurrentMana = Mathf.Max(0, Player.CurrentMana - Player.ManaConsumption);
        }
    }
}