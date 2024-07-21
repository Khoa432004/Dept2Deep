using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed;
    public int Health;
    public int CurrentHealth;
    public int Mana;
    public int CurrentMana;
    public int ManaConsumption;
    public int Damage;
    public int Def;
    public int Crit;
    public float AttackSpeed;
    public int AttackRange;
    private Vector2 Diadiem;

    //Roll
    protected int BoostSpeed = 3;
    protected float Cd = 0.5f;
    float CurrentTime;
    bool CheckRoll = false;

    //HP
    public HealthBar healthBar;
    public HealthBar manaBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveChar(Rigidbody2D myRigidBody2D)
    {
        Diadiem = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Diadiem.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        myRigidBody2D.velocity = Diadiem * MovementSpeed;

        Roll();
    }
    public void Roll()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && CurrentTime <= 0)
        {
            MovementSpeed += BoostSpeed;
            CurrentTime = Cd;
            CheckRoll = true;
        }
        else if(CurrentTime <= 0 && CheckRoll == true)
        {
            MovementSpeed -= BoostSpeed;
            CheckRoll = false;
        }
        else
        {
            CurrentTime -= Time.deltaTime;
        }
    }
}
