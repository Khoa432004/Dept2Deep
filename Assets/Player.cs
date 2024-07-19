using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed;
    public int Health;
    public int Mana;
    public int Damage;
    public int Def;
    public int Crit;
    public int AttackSpeed;
    public int AttackRange;
    // Start is called before the first frame update
    private Vector2 diadiem;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveChar(Rigidbody2D myRigidBody2D)
    {
        diadiem = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (diadiem.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        myRigidBody2D.velocity = diadiem * MovementSpeed;
    }
}
